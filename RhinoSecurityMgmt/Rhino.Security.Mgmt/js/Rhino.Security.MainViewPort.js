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
				closable: true,
				getWrappedElement: function () {
					return item;
				}
			}));
			_setTabIdentifier(tab, id);

			tab.show();
			return tab;
		}

		function _onOperationEditItem(sender, item) {
			var editTab = _openTab('Operation ' + Rhino.Security.Operation.toString(item), new Rhino.Security.OperationEditPanel(), 'Operation-' + item.StringId);
			editTab.getWrappedElement().loadItem(item.StringId);
		}
		function _onOperationNewItem(sender) {
			_openTab('New Operation', new Rhino.Security.OperationEditPanel(), 'Operation-new');
		}
		function _onOperationClick(sender, item) {
			var searchTab = _openTab('Search Operation', new Rhino.Security.OperationSearchPanel(), 'Operation-search');
			searchTab.getWrappedElement().on('edititem', _onOperationEditItem);
			searchTab.getWrappedElement().on('newitem', _onOperationNewItem);
		}

		function _onPermissionEditItem(sender, item) {
			var editTab = _openTab('Permission ' + Rhino.Security.Permission.toString(item), new Rhino.Security.PermissionEditPanel(), 'Permission-' + item.StringId);
			editTab.getWrappedElement().loadItem(item.StringId);
		}
		function _onPermissionNewItem(sender) {
			_openTab('New Permission', new Rhino.Security.PermissionEditPanel(), 'Permission-new');
		}
		function _onPermissionClick(sender, item) {
			var searchTab = _openTab('Search Permission', new Rhino.Security.PermissionSearchPanel(), 'Permission-search');
			searchTab.getWrappedElement().on('edititem', _onPermissionEditItem);
			searchTab.getWrappedElement().on('newitem', _onPermissionNewItem);
		}

		function _onUsersGroupEditItem(sender, item) {
			var editTab = _openTab('UsersGroup ' + Rhino.Security.UsersGroup.toString(item), new Rhino.Security.UsersGroupEditPanel(), 'UsersGroup-' + item.StringId);
			editTab.getWrappedElement().loadItem(item.StringId);
			editTab.getWrappedElement().on('itemupdated', function (updatedItem) {
				_setTabTitle(editTab, 'UsersGroup ' + Rhino.Security.UsersGroup.toString(updatedItem));
			});
		}
		function _onUsersGroupNewItem(sender) {
			var newTab = _openTab('New UsersGroup', new Rhino.Security.UsersGroupEditPanel(), 'UsersGroup-new');
			newTab.getWrappedElement().loadItem(null);
			newTab.getWrappedElement().on('itemupdated', function (updatedItem) {
				_setTabTitle(newTab, 'UsersGroup ' + Rhino.Security.User.toString(updatedItem));
				_setTabIdentifier(newTab, 'UsersGroup-' + updatedItem.StringId);
			});
		}
		function _onUsersGroupClick(sender, item) {
			var searchTab = _openTab('Search UsersGroup', new Rhino.Security.UsersGroupSearchPanel(), 'UsersGroup-search');
			searchTab.getWrappedElement().on('edititem', _onUsersGroupEditItem);
			searchTab.getWrappedElement().on('newitem', _onUsersGroupNewItem);
		}

		function _onUserEditItem(sender, item) {
			var editTab = _openTab('User ' + Rhino.Security.User.toString(item), new Rhino.Security.UserEditPanel(), 'User-' + item.StringId);
			editTab.getWrappedElement().loadItem(item.StringId);
			editTab.getWrappedElement().on('itemupdated', function (updatedItem) {
				_setTabTitle(editTab, 'User ' + Rhino.Security.User.toString(updatedItem));
			});
		}
		function _onUserNewItem(sender) {
			var newTab = _openTab('New User', new Rhino.Security.UserEditPanel(), 'User-new');
			newTab.getWrappedElement().loadItem(null);
			newTab.getWrappedElement().on('itemupdated', function (updatedItem) {
				_setTabTitle(newTab, 'User ' + Rhino.Security.User.toString(updatedItem));
				_setTabIdentifier(newTab, 'User-' + updatedItem.StringId);
			});
		}
		function _onUserClick(sender, item) {
			var searchTab = _openTab('Search User', new Rhino.Security.UserSearchPanel(), 'User-search');
			searchTab.getWrappedElement().on('edititem', _onUserEditItem);
			searchTab.getWrappedElement().on('newitem', _onUserNewItem);
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
					text: 'Manage Operations',
					children: [{
						text: 'Search',
						leaf: true,
						listeners: {
							click: _onOperationClick
						}
					}
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
					}
				]
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
					}
				]
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