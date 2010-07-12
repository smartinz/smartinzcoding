/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionsFormPanel = Ext.extend(Ext.Panel, {
	layout: 'border',
	initComponent: function () {
		var _this = this,
		_treePanel,
		_mainPanel = new Rhino.Security.PermissionsBuilderPanel({
			region: 'center'
		});

		_treePanel = new Ext.tree.TreePanel({
			title: 'Permissions',
			region: 'west',
			split: true,
			collapsible: true,
			width: 200,
			rootVisible: false,
			root: {
				text: 'Root Node',
				children: [{
					text: 'Manage Operations',
					children: [{
						text: 'Search',
						leaf: true,
						listeners: { 
							//click: _onOperationClick
						}
					}]
				},
				{
					text: 'Manage Permissions',
					children: [{
						text: 'Search',
						leaf: true
					}, {
						text: 'Create',
						leaf: true
					}]
				}]
			},
			loader: {}
		});

		_this.items = [_treePanel, _mainPanel];

		Rhino.Security.PermissionsFormPanel.superclass.initComponent.apply(_this, arguments);
	}
});