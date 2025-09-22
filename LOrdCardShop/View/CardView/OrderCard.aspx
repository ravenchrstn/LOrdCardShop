<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Customer.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="LOrdCardShop.View.CardView.OrderCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentCustomer" runat="server">
    <asp:Repeater ID="cardRepeater" runat="server">
        <HeaderTemplate>
            <h1 class="container mt-5 ps-5 text-white">Card List</h1>
            <div class="container d-flex justify-content-evenly text-white pb-5">
                <div class="row d-flex justify-content-evenly w-100">
        </HeaderTemplate>
        <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-12 pt-5 text-center w-33" style="min-width: 225px">
                        <asp:ImageButton ID="imageCardButton" runat="server" style="max-width: 225px; width: 100%;" ImageUrl='<%# GetCardUrl(Eval("CardName").ToString()) %>'/>
                        <div class="box d-flex flex-row information justify-content-center">
                            <div class="d-flex flex-column">
                                <div class="name">
                                    <%# Eval("CardName") %>
                                </div>
                                <div class="price">
                                    <%# Eval("CardPrice") %>
                                </div>
                                <div class="cart_detail d-flex gap-2 mt-2 justify-content-center">
                                    <asp:ImageButton ID="cartImageButton" runat="server" style="max-width: 30px; object-fit: contain" ImageUrl="~/Media/cart.png" CommandName="Cart" CommandArgument='<%# Eval("CardID") %>' OnCommand="cart_detail_Command"/>
                                    <asp:Button ID="detail" runat="server" Text="Detail" CssClass="btn btn-danger btn-sm" CommandName="Detail" CommandArgument='<%# Eval("CardID") %>' OnCommand="cart_detail_Command"/>
                                </div>
                            </div>
                        </div>
                    </div>
        </ItemTemplate>
        <FooterTemplate>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
