/*jslint white: true, browser: true, onevar: true, undef: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rhino.Security */
"use strict";
Ext.namespace('Rhino.Security');

Rhino.Security.EntitiesGroupField = Ext.extend(Ext.form.TriggerField, {
	editable: false,
	hideTrigger: true,
	initComponent: function () {
		var _this = this,
		_window,
		_selectedItem = null,
		_onEditEnded = function (sender, item) {
			_this.setValue(item);
			_window.hide();
		};

		Ext.apply(_this, {
			onTriggerClick: function () {
				_window = _window || new Rhino.Security.EntitiesGroupEditWindow({
					closeAction: 'hide',
					listeners: {
						editended: _onEditEnded
					}
				});
				_window.setItem(_selectedItem);
				_window.show(this.getEl());
			},
			beforeDestroy: function () {
				if (_window) {
					_window.close();
				}
				return Rhino.Security.EntitiesGroupField.superclass.beforeDestroy.apply(_this, arguments);
			},
			setValue: function (v) {
				_selectedItem = v;
				return Rhino.Security.EntitiesGroupField.superclass.setValue.call(_this, Rhino.Security.EntitiesGroup.toString(v));
			},
			getValue: function () {
				return _selectedItem;
			}
		});

		Rhino.Security.EntitiesGroupField.superclass.initComponent.apply(_this, arguments);
	}
});

Ext.reg('Rhino.Security.EntitiesGroupField', Rhino.Security.EntitiesGroupField);