/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino */
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

		function _setTabTitle(tab, title) {
			tab.setTitle(title);
		}
		function _setTabIdentifier(tab, id) {
			tab.tabContentIdentifier = id;
		}
		function _getTabIdentifier(tab) {
			return tab.tabContentIdentifier;
		}

		function _openTab(title, item, id) {
			var tab;

			Ext.each(_tabPanel.items.items, function (item) {
				if (_getTabIdentifier(item) === id) {
					tab = item;
					return false;
				}
			});

			tab = tab || _tabPanel.add(new Ext.Panel({
				layout: 'fit',
				items: item,
				title: title,
				closable: true
			}));
			_setTabIdentifier(tab, id);

			tab.show();
			return tab;
		}

		function _onOperationEditItem(sender, item) {
			var operationEditPanel = new Rhino.Security.OperationEditPanel();
			_openTab('Operation ' + Rhino.Security.Operation.toString(item), operationEditPanel, 'Operation-' + item.StringId);
			operationEditPanel.loadItem(item.StringId);
		}
		function _onOperationNewItem(sender) {
			_openTab('New Operation', new Rhino.Security.OperationEditPanel(), 'Operation-new');
		}
		function _onOperationClick(sender, item) {
			var operationSearchPanel = new Rhino.Security.OperationSearchPanel();
			_openTab('Search Operation', operationSearchPanel, 'Operation-search');
			operationSearchPanel.on('edititem', _onOperationEditItem);
			operationSearchPanel.on('newitem', _onOperationNewItem);
		}

		function _onPermissionEditItem(sender, item) {
			var permissionEditPanel = new Rhino.Security.PermissionEditPanel(),
			editTab = _openTab('Permission ' + Rhino.Security.Permission.toString(item), permissionEditPanel, 'Permission-' + item.StringId);
			permissionEditPanel.loadItem(item.StringId);
		}
		function _onPermissionNewItem(sender) {
			_openTab('New Permission', new Rhino.Security.PermissionEditPanel(), 'Permission-new');
		}
		function _onPermissionClick(sender, item) {
			var permissionSearchPanel = new Rhino.Security.PermissionSearchPanel(),
			searchTab = _openTab('Search Permission', permissionSearchPanel, 'Permission-search');
			permissionSearchPanel.on('edititem', _onPermissionEditItem);
			permissionSearchPanel.on('newitem', _onPermissionNewItem);
		}

		function _onUsersGroupEditItem(sender, item) {
			var userGroupEditPanel = new Rhino.Security.UsersGroupEditPanel(),
			editTab = _openTab('UsersGroup ' + Rhino.Security.UsersGroup.toString(item), userGroupEditPanel, 'UsersGroup-' + item.StringId);
			userGroupEditPanel.loadItem(item.StringId);
			userGroupEditPanel.on('itemupdated', function (updatedItem) {
				_setTabTitle(editTab, 'UsersGroup ' + Rhino.Security.UsersGroup.toString(updatedItem));
			});
		}
		function _onUsersGroupNewItem(sender) {
			var usersGroupEditPanel = new Rhino.Security.UsersGroupEditPanel(),
			newTab = _openTab('New UsersGroup', usersGroupEditPanel, 'UsersGroup-new');
			usersGroupEditPanel.loadItem(null);
			usersGroupEditPanel.on('itemupdated', function (updatedItem) {
				_setTabTitle(newTab, 'UsersGroup ' + Rhino.Security.User.toString(updatedItem));
				_setTabIdentifier(newTab, 'UsersGroup-' + updatedItem.StringId);
			});
		}
		function _onUsersGroupClick(sender, item) {
			var userGroupSearchPanel = new Rhino.Security.UsersGroupSearchPanel(),
			searchTab = _openTab('Search UsersGroup', userGroupSearchPanel, 'UsersGroup-search');
			userGroupSearchPanel.on('edititem', _onUsersGroupEditItem);
			userGroupSearchPanel.on('newitem', _onUsersGroupNewItem);
		}

		function _onUserEditItem(sender, item) {
			var userEditPanel = new Rhino.Security.UserEditPanel(),
			editTab = _openTab('User ' + Rhino.Security.User.toString(item), userEditPanel, 'User-' + item.StringId);
			userEditPanel.loadItem(item.StringId);
			userEditPanel.on('itemupdated', function (updatedItem) {
				_setTabTitle(editTab, 'User ' + Rhino.Security.User.toString(updatedItem));
			});
		}
		function _onUserNewItem(sender) {
			var userEditPanel = new Rhino.Security.UserEditPanel(),
			newTab = _openTab('New User', userEditPanel, 'User-new');
			userEditPanel.loadItem(null);
			userEditPanel.on('itemupdated', function (updatedItem) {
				_setTabTitle(newTab, 'User ' + Rhino.Security.User.toString(updatedItem));
				_setTabIdentifier(newTab, 'User-' + updatedItem.StringId);
			});
		}
		function _onUserClick(sender, item) {
			var userSearchPanel = new Rhino.Security.UserSearchPanel(),
			searchTab = _openTab('Search User', userSearchPanel, 'User-search');
			userSearchPanel.on('edititem', _onUserEditItem);
			userSearchPanel.on('newitem', _onUserNewItem);
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
				children: [
				//				{
				//					text: 'EntitiesGroup',
				//					children: [{
				//						text: 'Search EntitiesGroup',
				//						leaf: true,
				//						listeners: {
				//							click: _onEntitiesGroupClick
				//						}
				//					}, {
				//						text: 'Create EntitiesGroup',
				//						leaf: true,
				//						listeners: {
				//							click: _onEntitiesGroupNewItem
				//						}
				//					}]
				//				}, 
				//				{
				//					text: 'EntityReference',
				//					children: [{
				//						text: 'Search EntityReference',
				//						leaf: true,
				//						listeners: {
				//							click: _onEntityReferenceClick
				//						}
				//					}, {
				//						text: 'Create EntityReference',
				//						leaf: true,
				//						listeners: {
				//							click: _onEntityReferenceNewItem
				//						}
				//					}]
				//				}, 
				//				{
				//					text: 'EntityType',
				//					children: [{
				//						text: 'Search EntityType',
				//						leaf: true,
				//						listeners: {
				//							click: _onEntityTypeClick
				//						}
				//					}, {
				//						text: 'Create EntityType',
				//						leaf: true,
				//						listeners: {
				//							click: _onEntityTypeNewItem
				//						}
				//					}]
				//				}, 
				{
				text: 'Manage Operations',
				children: [{
					text: 'Search',
					leaf: true,
					listeners: {
						click: _onOperationClick
					}
				},
				//					{
				//						text: 'Create',
				//						leaf: true,
				//						listeners: {
				//							click: _onOperationNewItem
				//						}
				//					}
					]
			}, {
				text: 'Manage Permissions',
				children: [{
					text: 'Search',
					leaf: true,
					listeners: {
						click: _onPermissionClick
					}
				}, {
					text: 'Create',
					leaf: true,
					listeners: {
						click: _onPermissionNewItem
					}
				}]
			}, {
				text: 'Manage UsersGroups',
				children: [{
					text: 'Search',
					leaf: true,
					listeners: {
						click: _onUsersGroupClick
					}
				}, {
					text: 'Create',
					leaf: true,
					listeners: {
						click: _onUsersGroupNewItem
					}
				}]
			}, {
				text: 'Manage Users',
				children: [{
					text: 'Search',
					leaf: true,
					listeners: {
						click: _onUserClick
					}
				}, {
					text: 'Create',
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