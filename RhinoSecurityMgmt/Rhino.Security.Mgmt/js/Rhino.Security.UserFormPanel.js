/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino.Security */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.UserFormPanel = Ext.extend(Ext.form.FormPanel, {
	border: false,
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},

	initComponent: function () {
		// see http://www.extjs.com/forum/showthread.php?98131
		_pagingToolbar = new Ext.PagingToolbar({
//			store: _store,
			displayInfo: true,
			pageSize: 25,
			prependButtons: true
		}),
		_gridPanel = new Rhino.Security.UsersGroupGridPanel({
/*			region: 'center',
			store: _store,*/
			//bbar: _pagingToolbar
		}),
		
		this.items = [{
			layout: 'form',
			border: false,
			padding: 10,
			items: [
				{ name: 'StringId', xtype: 'hidden' },
				{ name: 'Id', fieldLabel: 'Id', xtype: 'numberfield' },
				{ name: 'Name', fieldLabel: 'Name', xtype: 'textfield' },
				{ 
					xtype: 'panel',
					title: 'Groups',
					collapsible: true,
					titleCollapse: true,
					tbar: {
						xtype: 'toolbar',
						items: [
							{ text: 'Add', icon: 'images/add.png', cls: 'x-btn-text-icon' },
							{ text: 'Delete', icon: 'images/delete.png', cls: 'x-btn-text-icon' }
						]
					},
					items: [ _gridPanel ]
				}
			]
		}, {
			flex: 1,
			xtype: 'tabpanel',
			plain: true,
			border: false,
			activeTab: 0,
			deferredRender: false, // IMPORTANT! See http://www.extjs.com/deploy/dev/examples/form/dynamic.js
			items: [
				{ name: 'Groups', title: 'Groups', xtype: 'Rhino.Security.UsersGroupListField' }
			]
		}];

		this.tbar = [
			{ text: 'Save', handler: this.saveItemButtonHandler, icon: 'images/disk.png', cls: 'x-btn-text-icon', scope: this },
			{ text: 'Refresh', handler: this.refreshItemButtonHandler, icon: 'images/arrow_refresh.png', cls: 'x-btn-text-icon', scope: this }
		];

		Rhino.Security.UserFormPanel.superclass.initComponent.apply(this, arguments);
	},

	loadItem: function (stringId) {
		this.el.mask('Loading...', 'x-mask-loading');
		Rpc.call({
			url: 'User/Load',
			params: { stringId: stringId },
			scope: this,
			success: function (item) {
				this.el.unmask();
				this.getForm().setValues(item);
			}
		});
	},

	saveItemButtonHandler: function () {
		this.el.mask('Saving...', 'x-mask-loading');
		Rpc.call({
			url: 'User/Save',
			params: { item: this.getForm().getFieldValues() },
			scope: this,
			success: function (result) {
				this.el.unmask();
				if (result.success) {
					Ext.MessageBox.show({ msg: 'Changes saved successfully.', icon: Ext.MessageBox.INFO, buttons: Ext.MessageBox.OK });
				} else {
					this.getForm().markInvalid(result.errors.item);
					Ext.MessageBox.show({ msg: 'Error saving data. Correct errors and retry.', icon: Ext.MessageBox.ERROR, buttons: Ext.MessageBox.OK });
				}
			}
		});
	},

	refreshItemButtonHandler: function () {
		Ext.MessageBox.confirm('Refresh', 'All modifications will be lost, continue?', function (buttonId) {
			if (buttonId === 'yes') {
				var stringId = this.getForm().getFieldValues().StringId;
				if (Ext.isEmpty(stringId)) {
					this.getForm().reset();
				} else {
					this.loadItem(stringId);
				}
			}
		}, this);
	}
});