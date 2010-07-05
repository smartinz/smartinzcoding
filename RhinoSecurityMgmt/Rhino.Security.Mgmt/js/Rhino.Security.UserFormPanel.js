/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.UserFormPanel = Ext.extend(Ext.form.FormPanel, {
	initComponent: function () {
		var _this = this;

		Ext.apply(_this, {
			border: false,
			padding: 10,
			items: [
				{ name: 'StringId', xtype: 'hidden' },
				{ name: 'Id', fieldLabel: 'Id', xtype: 'numberfield' },
				{ name: 'Name', fieldLabel: 'Name', xtype: 'textfield' }
			]
		});

		Rhino.Security.UserFormPanel.superclass.initComponent.apply(_this, arguments);
	}
});