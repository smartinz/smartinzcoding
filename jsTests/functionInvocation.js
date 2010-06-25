// MODULE PATTERN: it's used to hide state and implementation
String.prototype.deentityify = function () {
	var entity = {
		quot : '"',
		lt : '<',
		gt : '>'
	};
	
	return function () {
		return this.replace(/&([^&;]+);/g, function (a,b) {
				var r = entity[b];
				return typeof r === 'string' ? r : a; 
		});
	};
}(); // here is the key of pattern...the function is not only declared, it's also immediately invoked to return the inner function which is the only one having access to the entity lookup table

assertEquals("error", "&lt;".deentityify(), '<');
assertEquals("error", "&lt;&uhh;".deentityify(), '<&uhh;');



/*

var add_the_handlers = function(nodes) {
	var i;
	for(i = 0; i < nodes.length; i += 1) {
		node[i].onclick = function (i) {
			return function(e) {
				alert(e);
			};
		}(i);
	}
};

*/

var serial_maker = function () {
	var prefix = '';
	var seq = 0;
	
	return {
	
		set_prefix : function(p) {
		prefix = p;
		},
		
		set_seq : function(s) {
		seq = s;
		},

		generate_serial : function () {
		var t = prefix + seq;
		seq += 1;
		return t;
		}

	};
	
	
};

var setup = serial_maker();
setup.set_prefix('Q');
setup.set_seq(1000);

var generator = setup.generate_serial;
console.info(generator());