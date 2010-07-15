/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, Rhino */
"use strict";

Ext.namespace('Rhino.Security');

Rhino.Security.PermissionsBuilderPanel = Ext.extend(Ext.Panel, {
	initComponent: function () {
		var _this = this,
		_allowPermissionEditControl = new Rhino.Security.PermissionEditControl({
			name: 'allowed',
			title: 'Allowed'
		}),
		_denyPermissionEditControl = new Rhino.Security.PermissionEditControl({
			name: 'forbidden',
			title: 'Forbidden'
		}),
		_titleLabel = new Ext.form.Label({
			text: 'Permissions',
			hidden: true
		});

		Ext.apply(_this, {
			layout: 'vbox',
			layoutConfig: {
				align: 'stretch',
				pack: 'start'
			},
			border: false,
			padding: 20,
			items: [_titleLabel,
			{
				flex: 1,
				xtype: 'panel',
				layout: 'hbox',
				border: false,
				layoutConfig: {
					align: 'stretch',
					pack: 'start'
				},
				items: [_allowPermissionEditControl, _denyPermissionEditControl]
			}
			],
			loadPermissions: function (operationName) {
				_this.el.mask('Loading...', 'x-mask-loading');

				_titleLabel.setText('Permissions for operation \'' + operationName + '\'');

				Rpc.call({
					url: 'Permission/LoadByOperationName',
					params: { operationName: operationName },
					success: function (item) {
						_allowPermissionEditControl.setValue(item.allowed, operationName);
						_denyPermissionEditControl.setValue(item.forbidden, operationName);
						_this.el.unmask();
					}
				});
			}
		});

		Rhino.Security.PermissionsBuilderPanel.superclass.initComponent.apply(_this, arguments);
	}
});