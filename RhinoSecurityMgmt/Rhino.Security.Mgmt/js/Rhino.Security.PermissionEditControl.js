/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionEditControl = Ext.extend(Ext.Panel, {
	initComponent: function () {
		var _this = this;

		Ext.apply(_this, {
			layout: 'fit',
			align: 'stretch',
			border: false,
			items: [
				{
					xtype: 'panel',
					align: 'stretch',
					flex: 1,
					layout: 'fit',
					items: [
						{
							xtype: 'listview',
							columnResize: 'false'
//							columns: [
//								{
//									xtype: 'lvcolumn',
//									header: 'Column'
//								},
//								{
//									xtype: 'lvcolumn',
//									header: 'Column'
//								}
//							]
						}
					],
					fbar: {
						xtype: 'toolbar',
						buttonAlign: 'center',
						items: [
							{ xtype: 'button', text: 'Add User' },
							{ xtype: 'button', text: 'Add Group' }
						]
					}
				}
			]
		});

		Rhino.Security.PermissionEditControl.superclass.initComponent.apply(_this, arguments);
	}
});