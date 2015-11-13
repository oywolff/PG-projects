﻿<%@ Page Title="ContactsEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="Kampanjer.Contacts.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="Kampanjer.Models.Contacts" DefaultMode="Edit" DataKeyNames="ContactId"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Contacts with ContactId <%: Request.QueryString["ContactId"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit Contacts</legend>
					<asp:ValidationSummary runat="server" CssClass="alert alert-danger"  />                 
						    <asp:DynamicControl Mode="Edit" DataField="Name" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Address" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="City" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="State" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Zip" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Email" runat="server" />
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
							<asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
							<asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

