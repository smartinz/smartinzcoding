/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace("Rhino.Security");

Rhino.Security.UsersGroupGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [
				{ dataIndex: 'Id', header: 'Id', xtype: 'gridcolumn' }, { dataIndex: 'Name', header: 'Name', xtype: 'gridcolumn' }
			]
		});
		Rhino.Security.UsersGroupGridPanel.superclass.initComponent.apply(this, arguments);
	}
});