/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionSearchFormPanel = Ext.extend(Ext.form.FormPanel, {
	labelWidth: 100,
	border: false,
	padding: 10,
	initComponent: function () {
		this.items = [
			{ name: 'id', xtype: 'textfield', fieldLabel: 'id' },
			{ name: 'entitySecurityKey', xtype: 'textfield', fieldLabel: 'entitySecurityKey' },
			{ name: 'allow', xtype: 'checkbox', fieldLabel: 'allow' },
			{ name: 'level', xtype: 'numberfield', fieldLabel: 'level' },
			{ name: 'entityTypeName', xtype: 'textfield', fieldLabel: 'entityTypeName' }
		];
		Rhino.Security.PermissionSearchFormPanel.superclass.initComponent.apply(this, arguments);
	}
});