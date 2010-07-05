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
				<script type="text/javascript" src="js/Rhino.Security.UserSearchByGroupSearchPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntityReferenceSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntityTypeSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.OperationSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.PermissionSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UsersGroupSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UserSearchFormPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UserSearchByGroupSearchFormPanel.js"></script>
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
				<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntityReferenceEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntityTypeEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.OperationEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.PermissionEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UsersGroupEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UserEditWindow.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntitiesGroupEditPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntityReferenceEditPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.EntityTypeEditPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.OperationEditPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.PermissionEditPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UsersGroupEditPanel.js"></script>
				<script type="text/javascript" src="js/Rhino.Security.UserEditPanel.js"></script>
				
		<script type="text/javascript">
			"use strict";

			Ext.BLANK_IMAGE_URL = 'ext/resources/images/default/s.gif';
			Ext.USE_NATIVE_JSON = true;

			Ext.onReady(function () {
				Ext.QuickTips.init();
				var mainViewport = new Rhino.Security.MainViewport();
			});
		</script>
		<title></title>
	</head>
	<body>
	</body>
</html>