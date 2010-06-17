/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.EntitiesGroupSearchFormPanel = Ext.extend(Ext.form.FormPanel, {
	labelWidth: 100,
	border: false,
	padding: 10,
	initComponent: function () {
		this.items = [
			{ name: 'id', xtype: 'textfield', fieldLabel: 'id' },
			{ name: 'name', xtype: 'textfield', fieldLabel: 'name' }
		];
		Rhino.Security.EntitiesGroupSearchFormPanel.superclass.initComponent.apply(this, arguments);
	}
});