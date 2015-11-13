<%@ Page Title="ItemKeywordEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="Kampanjer.ItemKeywords.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="Kampanjer.Models.ItemKeyword" DefaultMode="Edit" DataKeyNames="ItemKeywordID"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the ItemKeyword with ItemKeywordID <%: Request.QueryString["ItemKeywordID"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit ItemKeyword</legend>
					<asp:ValidationSummary runat="server" CssClass="alert alert-danger"  />                 
						    <asp:DynamicControl Mode="Edit" DataField="VendorItemNo" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="ItemNo" runat="server" />
							<asp:DynamicControl Mode="Edit" 
								DataField="KeywordID" 
								DataTypeName="Kampanjer.Models.Keyword" 
								DataTextField="KeywordName" 
								DataValueField="KeywordID" 
								UIHint="ForeignKey" runat="server" />
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

