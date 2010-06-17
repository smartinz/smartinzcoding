/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace("Rhino.Security");

Rhino.Security.OperationGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [
				{ dataIndex: 'Id', header: 'Id', xtype: 'gridcolumn' }, { dataIndex: 'Name', header: 'Name', xtype: 'gridcolumn' }, { dataIndex: 'Comment', header: 'Comment', xtype: 'gridcolumn' }
			]
		});
		Rhino.Security.OperationGridPanel.superclass.initComponent.apply(this, arguments);
	}
});