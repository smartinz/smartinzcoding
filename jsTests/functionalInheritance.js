var person = function() {
	var that = {}, name;
	
	that.set_name = function(s) {
		name = s;
	};
	
	that.get_name = function() {
		return name;
	};
	
	return that;
};

var student = function() {
	var that = person();
	var id;
	
	return that;
}

var myStudent = student();
myStudent.set_name('stefano');
student.name = "ciccio";
//console.info(myStudent.get_name());
assertEquals("error", myStudent.get_name(), 'stefano');
//console.info(myStudent.name);
assertEquals("error", myStudent.name, undefined);
assertEquals("error", myStudent.id, undefined);

