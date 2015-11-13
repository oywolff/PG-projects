<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNokkelord.aspx.cs" Inherits="Kampanjer.AddNokkelord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
    <asp:FormView runat="server" ID="addNøkkelord"
        ItemType="Kampanjer.Models.Keyword"
        insertMethod="addNøkkelord_InsertItem" DefaultMode="Insert"
        RenderOuterTable="false" OnItemInserted ="addNøkkelord_ItemInserted">
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:DynamicEntity runat="server" Mode="Insert" />
                </ol>
            <asp:Button runat="server" Text="Opprett" CommandName="Insert" />
            <asp:Button runat="server" Text="Avbryt" CausesValidation="false" OnClick="cancelButton_Click" />
            </fieldset>
        </InsertItemTemplate>


    </asp:FormView>

</asp:Content>
