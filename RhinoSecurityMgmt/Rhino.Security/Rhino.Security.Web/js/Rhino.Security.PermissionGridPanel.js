/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace("Rhino.Security");

Rhino.Security.PermissionGridPanel = Ext.extend(Ext.grid.GridPanel, {
	border: false,
	initComponent: function () {
		this.colModel = new Ext.grid.ColumnModel({
			defaults: { width: 60, sortable: true },
			columns: [
				{ dataIndex: 'Id', header: 'Id', xtype: 'gridcolumn' }, { dataIndex: 'EntitySecurityKey', header: 'EntitySecurityKey', xtype: 'gridcolumn' }, { dataIndex: 'Allow', header: 'Allow', xtype: 'booleancolumn' }, { dataIndex: 'Level', header: 'Level', xtype: 'numbercolumn' }, { dataIndex: 'EntityTypeName', header: 'EntityTypeName', xtype: 'gridcolumn' }, { dataIndex: 'EntitiesGroup', header: 'EntitiesGroup', xtype: 'Rhino.Security.EntitiesGroupColumn' }, { dataIndex: 'Operation', header: 'Operation', xtype: 'Rhino.Security.OperationColumn' }
			]
		});
		Rhino.Security.PermissionGridPanel.superclass.initComponent.apply(this, arguments);
	}
});