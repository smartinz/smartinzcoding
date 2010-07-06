/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'border',
	initComponent: function () {
		var _this = this,
		_treePanel,
		_tabPanel = new Ext.TabPanel({
			activeTab: 0,
			region: 'center',
			items: [{
				xtype: 'panel',
				title: 'Welcome Page'
			}]
		});

		function _openTab (title, Constructor) {
			var tab;

			Ext.each(_tabPanel.items.items, function (item) {
				if (item.title === title) {
					tab = item;
					return false;
				}
			});

			tab = tab || _tabPanel.add(new Constructor({
				title: title,
				closable: true
			}));

			tab.show();
			return tab;
		}

						function _onEntitiesGroupEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.EntitiesGroup.toString(item);
							editTab = _openTab('EntitiesGroup ' + description, Rhino.Security.EntitiesGroupEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onEntitiesGroupNewItem (sender) {
							_openTab('New EntitiesGroup', Rhino.Security.EntitiesGroupEditPanel);
						}
						function _onEntitiesGroupClick (sender, item) {
							var searchTab = _openTab('Search EntitiesGroup', Rhino.Security.EntitiesGroupSearchPanel);
							searchTab.on('edititem', _onEntitiesGroupEditItem);
							searchTab.on('newitem', _onEntitiesGroupNewItem);
						}
						
						function _onEntityReferenceEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.EntityReference.toString(item);
							editTab = _openTab('EntityReference ' + description, Rhino.Security.EntityReferenceEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onEntityReferenceNewItem (sender) {
							_openTab('New EntityReference', Rhino.Security.EntityReferenceEditPanel);
						}
						function _onEntityReferenceClick (sender, item) {
							var searchTab = _openTab('Search EntityReference', Rhino.Security.EntityReferenceSearchPanel);
							searchTab.on('edititem', _onEntityReferenceEditItem);
							searchTab.on('newitem', _onEntityReferenceNewItem);
						}
						
						function _onEntityTypeEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.EntityType.toString(item);
							editTab = _openTab('EntityType ' + description, Rhino.Security.EntityTypeEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onEntityTypeNewItem (sender) {
							_openTab('New EntityType', Rhino.Security.EntityTypeEditPanel);
						}
						function _onEntityTypeClick (sender, item) {
							var searchTab = _openTab('Search EntityType', Rhino.Security.EntityTypeSearchPanel);
							searchTab.on('edititem', _onEntityTypeEditItem);
							searchTab.on('newitem', _onEntityTypeNewItem);
						}
						
						function _onOperationEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.Operation.toString(item);
							editTab = _openTab('Operation ' + description, Rhino.Security.OperationEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onOperationNewItem (sender) {
							_openTab('New Operation', Rhino.Security.OperationEditPanel);
						}
						function _onOperationClick (sender, item) {
							var searchTab = _openTab('Search Operation', Rhino.Security.OperationSearchPanel);
							searchTab.on('edititem', _onOperationEditItem);
							searchTab.on('newitem', _onOperationNewItem);
						}
						
						function _onPermissionEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.Permission.toString(item);
							editTab = _openTab('Permission ' + description, Rhino.Security.PermissionEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onPermissionNewItem (sender) {
							_openTab('New Permission', Rhino.Security.PermissionEditPanel);
						}
						function _onPermissionClick (sender, item) {
							var searchTab = _openTab('Search Permission', Rhino.Security.PermissionSearchPanel);
							searchTab.on('edititem', _onPermissionEditItem);
							searchTab.on('newitem', _onPermissionNewItem);
						}
						
						function _onUsersGroupEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.UsersGroup.toString(item);
							editTab = _openTab('UsersGroup ' + description, Rhino.Security.UsersGroupEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onUsersGroupNewItem (sender) {
							_openTab('New UsersGroup', Rhino.Security.UsersGroupEditPanel);
						}
						function _onUsersGroupClick (sender, item) {
							var searchTab = _openTab('Search UsersGroup', Rhino.Security.UsersGroupSearchPanel);
							searchTab.on('edititem', _onUsersGroupEditItem);
							searchTab.on('newitem', _onUsersGroupNewItem);
						}
						
						function _onUserEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.User.toString(item);
							editTab = _openTab('User ' + description, Rhino.Security.UserEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onUserNewItem (sender) {
							_openTab('New User', Rhino.Security.UserEditPanel);
						}
						function _onUserClick (sender, item) {
							var searchTab = _openTab('Search User', Rhino.Security.UserSearchPanel);
							searchTab.on('edititem', _onUserEditItem);
							searchTab.on('newitem', _onUserNewItem);
						}
								function _onUserSearchByGroupEditItem (sender, item) {
							var editTab, description;
							description = Rhino.Security.User.toString(item);
							editTab = _openTab('User ' + description, Rhino.Security.UserEditPanel);
							editTab.loadItem(item.StringId);
						}
						function _onUserNewItem (sender) {
							_openTab('New User', Rhino.Security.UserEditPanel);
						}
						function _onUserSearchByGroupClick (sender, item) {
							var searchTab = _openTab('Search User SearchByGroup', Rhino.Security.UserSearchByGroupSearchPanel);
							searchTab.on('edititem', _onUserSearchByGroupEditItem);
							searchTab.on('newitem', _onUserNewItem);
						}
						
				
		_treePanel = new Ext.tree.TreePanel({
			title: 'Main Menu',
			region: 'west',
			split: true,
			collapsible: true,
			width: 200,
			rootVisible: false,
			root: {
				text: 'Root Node',
				children: [{
					text: 'EntitiesGroup',
					children: [{
						text: 'Search EntitiesGroup',
						leaf: true,
						listeners: {
							click: _onEntitiesGroupClick
						}
					}, {
						text: 'Create EntitiesGroup',
						leaf: true,
						listeners: {
							click: _onEntitiesGroupNewItem
						}
					}]
				}, {
					text: 'EntityReference',
					children: [{
						text: 'Search EntityReference',
						leaf: true,
						listeners: {
							click: _onEntityReferenceClick
						}
					}, {
						text: 'Create EntityReference',
						leaf: true,
						listeners: {
							click: _onEntityReferenceNewItem
						}
					}]
				}, {
					text: 'EntityType',
					children: [{
						text: 'Search EntityType',
						leaf: true,
						listeners: {
							click: _onEntityTypeClick
						}
					}, {
						text: 'Create EntityType',
						leaf: true,
						listeners: {
							click: _onEntityTypeNewItem
						}
					}]
				}, {
					text: 'Operation',
					children: [{
						text: 'Search Operation',
						leaf: true,
						listeners: {
							click: _onOperationClick
						}
					}, {
						text: 'Create Operation',
						leaf: true,
						listeners: {
							click: _onOperationNewItem
						}
					}]
				}, {
					text: 'Permission',
					children: [{
						text: 'Search Permission',
						leaf: true,
						listeners: {
							click: _onPermissionClick
						}
					}, {
						text: 'Create Permission',
						leaf: true,
						listeners: {
							click: _onPermissionNewItem
						}
					}]
				}, {
					text: 'UsersGroup',
					children: [{
						text: 'Search UsersGroup',
						leaf: true,
						listeners: {
							click: _onUsersGroupClick
						}
					}, {
						text: 'Create UsersGroup',
						leaf: true,
						listeners: {
							click: _onUsersGroupNewItem
						}
					}]
				}, {
					text: 'User',
					children: [{
						text: 'Search User',
						leaf: true,
						listeners: {
							click: _onUserClick
						}
					}, {
						text: 'Create User',
						leaf: true,
						listeners: {
							click: _onUserNewItem
						}
					}]
				}]
			},
			loader: {}
		});

		this.items = [_treePanel, _tabPanel];

		Rhino.Security.MainViewport.superclass.initComponent.apply(this, arguments);
	}
});