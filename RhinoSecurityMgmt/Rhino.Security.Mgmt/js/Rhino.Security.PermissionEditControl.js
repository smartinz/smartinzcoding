/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino */
"use strict";

Ext.namespace('Rhino.Security');


Rhino.Security.PermissionEditControl = Ext.extend(Ext.Panel, {
	initComponent: function () {
		var _this = this,
		_listView,

		/*TEST*/
		_data =
		[
			['stefano'],
			['gimmi']
		],
		_store = new Ext.data.ArrayStore({
			fields: ['description']
		});
		_store.loadData(_data);
		/*END TEST*/

		_listView = new Ext.list.ListView({
			store: _store,
			multiSelect: true,
			hideHeaders: true,
			columns: [
				{
					//header: 'users and groups',
					width: 0.5,
					dataIndex: 'description'
				}
			]
		});

		Ext.apply(_this, {
			layout: 'fit',
			align: 'stretch',
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
					{ xtype: 'button', text: 'Add User' },
					{ xtype: 'button', text: 'Add Group' }
				]
			},
		});

		Rhino.Security.PermissionEditControl.superclass.initComponent.apply(_this, arguments);
	}
});