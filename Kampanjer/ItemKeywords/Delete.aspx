<%@ Page Title="ItemKeywordDelete" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Delete.aspx.cs" Inherits="Kampanjer.ItemKeywords.Delete" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <h3>Are you sure want to delete this ItemKeyword?</h3>
        <asp:FormView runat="server"
            ItemType="Kampanjer.Models.ItemKeyword" DataKeyNames="ItemKeywordID"
            DeleteMethod="DeleteItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the ItemKeyword with ItemKeywordID <%: Request.QueryString["ItemKeywordID"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Delete ItemKeyword</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Varenummer</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="VendorItemNo" ID="VendorItemNo" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>ItemNo</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="ItemNo" ID="ItemNo" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>KeywordID</strong>
								</div>
								<div class="col-sm-4">
									<%#: Item.Keyword != null ? Item.Keyword.KeywordName : "" %>
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

