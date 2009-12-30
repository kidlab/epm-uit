
function toggleSlide(id, controlId ,class1, control){
	if ($("#" + id).hasClass(class1))
	{
		$("#" + id).removeClass(class1);
		if (control == 'up')
			$("#" + controlId).slideUp('slow');
		else 
			$("#" + controlId).slideDown('slow');
	}
	else {
		$("#" + id).addClass(class1);
		if (control == 'up')
			$("#" + controlId).slideDown('slow');
		else 
			$("#" + controlId).slideUp('slow');
	}
}