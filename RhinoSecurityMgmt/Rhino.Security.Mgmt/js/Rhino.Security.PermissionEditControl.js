/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionEditControl = Ext.extend(Ext.Panel, {
	initComponent: function () {
		var _this = this,

		_store = new Ext.data.Store({
			autoDestroy: true,
			remoteSort: false,
			proxy: new Ext.data.MemoryProxy({ items: [] }),
			reader: new Rhino.Security.PermissionReadJsonReader()
		}),

		_listView = new Ext.list.ListView({
			flex: 1,
			store: _store,
			multiSelect: true,
			hideHeaders: true,
			columns: [
				{
					width: 0.5,
					dataIndex: 'description'
				}
			]
		}),

		_onEditEnded = function (window, item) {
			var currentItems = _this.getValue(),
			found = false,
			i,
			count = currentItems.length;
			for (i = 0; i < count; i += 1) {
				if (currentItems[i] && currentItems[i].id && currentItems[i].id === item.id) {
					found = true;
					break;
				}
			}

			if (!found) {
				currentItems.push({ id: item.Id, description: item.Name });
			}

			_listView.getStore().load();
			window.close();
		},

		_buildWindow = function (action) {
			if (action === 'addUser') {
				return new Rhino.Security.UserEditWindow({
					listeners: {
						editended: _onEditEnded
					}
				});
			}
			else {
				return new Rhino.Security.UsersGroupEditWindow({
					listeners: {
						editended: _onEditEnded
					}
				});
			}
		},

		_onAddUserButtonClick = function (button) {
			var window = _buildWindow('addUser');
			window.show(button.getEl());
		},

		_onAddUsersGroupButtonClick = function (button) {
			var window = _buildWindow('addUsersGroup');
			window.show(button.getEl());
		};

		Ext.apply(_this, {
			layout: 'fit',
			layoutConfig: {
				align: 'stretch'
			},
			border: true,
			margins: {
				top: 10,
				right: 20,
				bottom: 10,
				left: 10
			},
			items: [_listView],
			fbar: {
				xtype: 'toolbar',
				buttonAlign: 'center',
				items: [
					{
						xtype: 'button',
						text: 'Add User',
						listeners: {
							click: _onAddUserButtonClick
						}
					},
					{
						xtype: 'button',
						text: 'Add Group',
						listeners: {
							click: _onAddUsersGroupButtonClick
						}
					}
				]
			},
			setValue: function (v) {
				_listView.getStore().proxy.data.items = v;
				_listView.getStore().load();
			},
			getValue: function () {
				return _listView.getStore().proxy.data.items;
			}
		});

		Rhino.Security.PermissionEditControl.superclass.initComponent.apply(_this, arguments);
	}
});

Ext.reg('Rhino.Security.PermissionEditControl', Rhino.Security.PermissionEditControl);