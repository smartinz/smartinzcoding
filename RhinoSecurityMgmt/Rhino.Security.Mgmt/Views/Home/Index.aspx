<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!doctype html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="ext/resources/css/ext-all.css" />

	<script type="text/javascript" src="ext/adapter/ext/ext-base-debug-w-comments.js"></script>

	<script type="text/javascript" src="ext/ext-all-debug-w-comments.js"></script>

	<script type="text/javascript" src="js/Rpc.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserGridPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserJsonReader.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserSearchPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserSearchFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserFormPanel.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserListField.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.MainViewPort.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferenceColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypeColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserColumn.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroup.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReference.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityType.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.Operation.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.Permission.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroup.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.User.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupPickerWindow.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityReferencePickerWindow.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.EntityTypePickerWindow.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.OperationPickerWindow.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.PermissionPickerWindow.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UsersGroupPickerWindow.js"></script>

	<script type="text/javascript" src="js/Rhino.Security.UserPickerWindow.js"></script>

	<script type="text/javascript">
		"use strict";

		Ext.BLANK_IMAGE_URL = 'ext/resources/images/default/s.gif';
		Ext.USE_NATIVE_JSON = true;

		Ext.onReady(function() {
			Ext.QuickTips.init();
			var mainViewport = new Rhino.Security.MainViewport();
		});
		</script>

	<title></title>
</head>
<body>
</body>
</html>
