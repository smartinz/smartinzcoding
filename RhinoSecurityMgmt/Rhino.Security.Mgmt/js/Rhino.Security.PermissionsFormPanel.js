/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionsFormPanel = Ext.extend(Ext.Panel, {
	layout: 'border',
	initComponent: function () {
		var _this = this,
		_onOperationClick,
		_operationsTreePanel,
		_permissionsBuilderPanel = new Rhino.Security.PermissionsBuilderPanel({
			region: 'center'
		});

		_onOperationClick = function (sender, item) {
			_permissionsBuilderPanel.loadPermissions(sender.id);
		};

		_onNodeAppended = function (tree, parent, node, index) {
			node.on('click', _onOperationClick);
		};

		_operationsTreePanel = new Ext.tree.TreePanel({
			title: 'Operations',
			border: false,
			region: 'west',
			split: true,
			collapsible: true,
			width: 200,
			listeners: {
				append: _onNodeAppended
			},
			dataUrl: 'Operation/GetAllAsTree',
			root: {
				text: 'All',
				id: 'id'
			}
		});

		_operationsTreePanel.getRootNode().expand();

		_this.items = [_operationsTreePanel, _permissionsBuilderPanel];

		Rhino.Security.PermissionsFormPanel.superclass.initComponent.apply(_this, arguments);
	}
});