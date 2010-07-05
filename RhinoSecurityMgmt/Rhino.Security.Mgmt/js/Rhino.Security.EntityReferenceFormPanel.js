/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.EntityReferenceFormPanel = Ext.extend(Ext.form.FormPanel, {
	initComponent: function () {
		var _this = this;

		Ext.apply(_this, {
			border: false,
			padding: 10,
			items: [
				{ name: 'StringId', xtype: 'hidden' },
				{ name: 'Id', fieldLabel: 'Id', xtype: 'textfield' },
				{ name: 'EntitySecurityKey', fieldLabel: 'EntitySecurityKey', xtype: 'textfield' }
			]
		});

		Rhino.Security.EntityReferenceFormPanel.superclass.initComponent.apply(_this, arguments);
	}
});