/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.AllPermissionsByOperationJsonReader.js = Ext.extend(Rpc.JsonReader, {
	constructor: function (meta, recordType) {
		var cfg = {
			root: 'items',
			idProperty: 'StringId',
			totalProperty: 'count',
			fields: [
				'allowed', 
				'forbidden'
			]
		};
		Rhino.Security.AllPermissionsByOperationJsonReader.js.superclass.constructor.call(this, Ext.apply(meta || {}, cfg), recordType);
	}
});