/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.EntitiesGroup = {
	toString: function (o) {
		if(o) {
			return o.Description || o.StringId || 'Not a Rhino.Security.EntitiesGroup';
		}
		return '';
	}
};