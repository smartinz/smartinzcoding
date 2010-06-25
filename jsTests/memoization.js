// Fibonacci w/o memoization
var cont=0;
var fibonacci = function (n) {
	cont +=1;
	return n < 2 ? n : fibonacci(n-1) + fibonacci(n-2);
}

for(var i = 0; i <= 10; i += 1) {
	fibonacci(i);
}
console.info(cont);
assertEquals("error", cont, 453);

cont = 0;

// Fibonacci with memoization
var fibonacci_memoizated = function () {
	var memo = [0,1];
	var fib = function(m) {
		cont += 1;	
		var result = memo[m];
		if (typeof result !== 'number') {
			result = m < 2 ? m : fib(m-1) + fib(m-2);
			memo[m] = result;
		}
		return result;
	};
	
	return fib;
}();

for(var i = 0; i <= 10; i += 1) {
	fibonacci_memoizated(i);
}
console.info(cont);
assertEquals("error", cont, 29);

// Now generalize the pattern

cont = 0;

var memoizer = function (memo, func) {
	var shell = function(n) {
		cont += 1;	
		var result = memo[n];
		if (typeof result !== 'number') {
			result = func(shell, n);
			memo[n] = result;
		}
		return result;
	};
	
	return shell;
};

var fibonacci_generic = memoizer([0,1], function (fib, n) {
		return fib(n - 1) + fib(n - 2);
	});

	
for(var i = 0; i <= 10; i += 1) {
	fibonacci_generic(i);
}

console.info(cont);
//assertEquals("error", cont, 29);