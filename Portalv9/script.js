var popUp; 

function OpenCalendar(idname, postBack)
{
    popUp = window.open('Calendar.aspx?formname=' + document.forms[0].name + 
		'&id=' + idname + '&selected=' + document.forms[0].elements[idname].value + '&postBack=' + postBack, 
		'popupcal', 
		'width=165,height=230,left=200,top=250');			
}

function SetDate(formName, id, newDate, postBack)
{
	eval('var theform = document.' + formName + ';');
	popUp.close();
	theform.elements[id].value = newDate;
	//if (postBack)
		//__doPostBack(id,'');
}		



//*******************************************************
//
// The CaptureEnter function is used to respond to the keypress
// event for text boxes.  Normally if the user presses Enter
// in a text box, the default ASP.NET behavior is to postback
// to the first button of the page.  Therefore only the first
// button's Click event handler will be called.  This does 
// not work properly for this page because we have different
// sections that should postback to different buttons. By 
// calling this function and passing the proper button 
// parameter, we can control which button actually gets 
// "clicked" on.
//
//*******************************************************

function CaptureEnter(event, button) {
	if (event.keyCode == 13) {
		// Hit enter key, so do a virtual click
		button.click();
		
		if (document.all) {
			event.keyCode = null;
		} else {
			event.cancelBubble = true;
			event.returnValue = false;
		}
	}
}
