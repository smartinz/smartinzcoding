/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionsBuilderPanel = Ext.extend(Ext.Panel, {
	initComponent: function () {
		var _this = this,
		_allowPermissionEditControl = new Rhino.Security.PermissionEditControl(),
		_denyPermissionEditControl = new Rhino.Security.PermissionEditControl();

		Ext.apply(_this, {
			layout: 'hbox',
			border: false,
			items: [ _allowPermissionEditControl ] //, _denyPermissionEditControl ]
		});

		Rhino.Security.PermissionsBuilderPanel.superclass.initComponent.apply(_this, arguments);
	}
});