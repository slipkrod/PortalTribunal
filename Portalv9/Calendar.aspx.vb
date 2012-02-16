Imports System
Imports System.Web.UI.WebControls
Imports System.Configuration

Namespace ASPNET.StarterKit.TimeTracker.Web

    '*****************************************************************************
    '
    ' The calendar page allows the user to select a date.  It's used as a popup
    ' window on several pages in the Time Tracker application.
    '
    '*****************************************************************************

    Partial Class Calendar
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '**************************************************************************
        '
        ' The calendar page is used to display a popup calendar to users from
        ' several different pages in the Time Tracker application.  It's primary
        ' job is to allow the user to select a date.
        '
        '**************************************************************************

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim selected As String = Request.QueryString("selected")
                Dim id As String = Request.QueryString("id")
                Dim form As String = Request.QueryString("formname")
                Dim postBack As String = Request.QueryString("postBack")

                ' Cast first day of the week from web.config file.  Set it to the calendar
                Cal.FirstDayOfWeek = CType(Convert.ToInt32(ConfigurationManager.AppSettings(Global_asax.CfgKeyFirstDayOfWeek)), System.Web.UI.WebControls.FirstDayOfWeek)

                ' Select the Correct date for Calendar from query string
                ' If fails, pick the current date on Calendar
                Try
                    Cal.SelectedDate = Convert.ToDateTime(selected)
                    Cal.VisibleDate = Convert.ToDateTime(selected)
                Catch
                    Cal.SelectedDate = DateTime.Today
                    Cal.VisibleDate = DateTime.Today
                End Try

                ' Fills in correct values for the dropdown menus
                FillCalendarChoices()
                SelectCorrectValues()

                ' Add JScript to the OK button so that when the user clicks on it, the selected date
                ' is passed back to the calling page.
                OKButton.Attributes.Add("onClick", "window.opener.SetDate('" + form + "','" + id + "', document.Calendar.datechosen.value," + postBack + ");")
                CancelButton.Attributes.Add("onClick", "CloseWindow()")
            End If
        End Sub 'Page_Load

        '***************************************************************
        '
        ' FillCalendarChoices method is used to fill dropdowns with month and year values 
        ' 
        '***************************************************************

        Private Sub FillCalendarChoices()
            Dim thisdate As New DateTime(DateTime.Today.Year, 1, 1)

            ' Fills in month values
            Dim x As Integer
            For x = 0 To 11
                ' Loops through 12 months of the year and fills in each month value
                Dim li As New ListItem(thisdate.ToString("MMMM"), thisdate.Month.ToString())
                MonthSelect.Items.Add(li)
                thisdate = thisdate.AddMonths(1)
            Next x

            ' Fills in year values and change y value to other years if necessary
            Dim y As Integer

            'plno  For y = 1994 To thisdate.Year
            For y = 1970 To thisdate.Year
                YearSelect.Items.Add(y.ToString())
            Next y
        End Sub 'FillCalendarChoices


        '***************************************************************************
        '
        ' The SelectCorrectValues method is used to select the correct values in dropdowns 
        ' according to the selected date on Calendar
        '
        '***************************************************************************

        Private Sub SelectCorrectValues()
            lblDate.Text = Cal.SelectedDate.ToShortDateString()
            datechosen.Value = lblDate.Text
            MonthSelect.SelectedIndex = MonthSelect.Items.IndexOf(MonthSelect.Items.FindByValue(Cal.SelectedDate.Month.ToString()))
            YearSelect.SelectedIndex = YearSelect.Items.IndexOf(YearSelect.Items.FindByValue(Cal.SelectedDate.Year.ToString()))
        End Sub 'SelectCorrectValues

        '**************************************************************************
        '
        ' Cal_SelectionChanged event handler highlights the selected date on the Calendar and
        ' calls SelectCorrectValues() to synchronize to correct values on dropdowns.
        '
        '**************************************************************************

        Private Sub Cal_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cal.SelectionChanged
            Cal.VisibleDate = Cal.SelectedDate
            SelectCorrectValues()
        End Sub 'Cal_SelectionChanged

        '**************************************************************************
        '
        ' MonthSelect_SelectedIndexChanged event handler selects the first day of the month when
        ' a month selection has being changed.
        '
        '**************************************************************************

        Private Sub MonthSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthSelect.SelectedIndexChanged
            Cal.VisibleDate = New DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value), Convert.ToInt32(MonthSelect.SelectedItem.Value), 1)
            Cal.SelectedDate = Cal.VisibleDate
            SelectCorrectValues()
        End Sub 'MonthSelect_SelectedIndexChanged

        '**************************************************************************
        '
        ' YearSelect_SelectedIndexChanged event handler selects a year value on the Calendar control
        ' when a year selection has being changed.
        '
        '**************************************************************************

        Private Sub YearSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearSelect.SelectedIndexChanged
            Cal.VisibleDate = New DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value), Convert.ToInt32(MonthSelect.SelectedItem.Value), 1)
            Cal.SelectedDate = Cal.VisibleDate
            SelectCorrectValues()
        End Sub 'YearSelect_SelectedIndexChanged

    End Class 'Calendar
End Namespace 'ASPNET.StarterKit.TimeTracker.Web



