/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";
Ext.namespace('Rhino.Security');

Rhino.Security.EntityReferenceField = Ext.extend(Ext.form.TriggerField, {
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
				_window = _window || new Rhino.Security.EntityReferencePickerWindow({
					listeners: {
						itemselected: _onItemSelected
					}
				});
				_window.show(this.getEl());
			},
			setValue: function (v) {
				_selectedItem = v;
				return Rhino.Security.EntityReferenceField.superclass.setValue.call(_this, Rhino.Security.EntityReference.toString(v));
			},
			getValue: function () {
				return _selectedItem;
			}
		});

		Rhino.Security.EntityReferenceField.superclass.initComponent.apply(this, arguments);
	}
});

Ext.reg('Rhino.Security.EntityReferenceField', Rhino.Security.EntityReferenceField);