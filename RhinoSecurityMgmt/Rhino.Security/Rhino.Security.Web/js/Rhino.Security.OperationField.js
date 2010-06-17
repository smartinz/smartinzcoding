/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";
Ext.namespace('Rhino.Security');

Rhino.Security.OperationField = Ext.extend(Ext.form.TriggerField, {
	editable: false,
	hideTrigger: true,
	initComponent: function () {
		var _this = this,
		_window,
		_selectedItem = null,
		_onItemSelected = function (sender, item) {
			_this.setValue(item);
			_window.hide();
		};

		Ext.apply(_this, {
			onTriggerClick: function () {
				_window = _window || new Rhino.Security.OperationPickerWindow({
					listeners: {
						itemselected: _onItemSelected
					}
				});
				_window.show(this.getEl());
			},
			setValue: function (v) {
				_selectedItem = v;
				return Rhino.Security.OperationField.superclass.setValue.call(_this, Rhino.Security.Operation.toString(v));
			},
			getValue: function () {
				return _selectedItem;
			}
		});

		Rhino.Security.OperationField.superclass.initComponent.apply(this, arguments);
	}
});

Ext.reg('Rhino.Security.OperationField', Rhino.Security.OperationField);