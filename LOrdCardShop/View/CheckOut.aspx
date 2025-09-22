<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Customer.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="LOrdCardShop.View.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentCustomer" runat="server">
        <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .cart {
            display: flex;
            flex-direction: column;
            margin: 50px 10% 50px;
            gap: 35px;
            width: 100%;
        }

        .title {
            font-weight: bold;
            font-size: 32px;
        }

        .content {
            display: flex;
            width: 100%;
        }

        .item {
            display: flex;
            width: 100%;
        }

        .itemImage {
            width: 100px;
        }

        .name-price-description {
            display: flex;
            width: 100%;
            flex-direction: column;
            padding: 15px 0 0 30px;
            gap: 5px;
        }

        .name {
            color: lightgray;
            font-size: 18px;
        }

        .price {
            font-size: 15px;
        }

        .description {
            font-size: 13px;
        }

        .quantity {
            font-size: 15px;
        }

        .check_out_total_price {
            display: flex;
            justify-content: space-between;
        }

    </style>

    <asp:Repeater ID="checkOutRepeater" runat="server" OnItemDataBound="checkOutRepeater_ItemDataBound">
        <HeaderTemplate>
            <div class="cart">
                <div class="title">
                    Check Out
                </div>
        </HeaderTemplate>
        <ItemTemplate>
                <div class="content">
                    <div class="item">
                        <asp:Image ID="itemImage" runat="server" class="itemImage" ImageUrl=<%# GetCardUrl(Eval("CardID").ToString())%>/>
                        <div class="name-price-description">
                            <div class="name">
                                <asp:Label ID="name" runat="server" Text=<%# GetCardName(Eval("CardID").ToString()) %>></asp:Label>                        
                            </div>
                            <div class="description">
                                <asp:Label ID="description" runat="server" Style="color: lightgray" Text=<%# GetCardDescription(Eval("CardID").ToString())%>></asp:Label>
                            </div>
                            <div class="quantity">
                                <asp:Label ID="quantity" runat="server" Text=<%# GetQuantity(Eval("Quantity").ToString()) %>></asp:Label>
                            </div>
                            <div class="price">
                                <asp:Label ID="price" runat="server" Text=<%# GetCardPrice(Eval("CardID").ToString())%>></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
        </ItemTemplate>
        <FooterTemplate>
                <div class="check_out_total_price">
                    <asp:Button ID="checkOutButton" Style="color: white; width: 120px; font-size: 16px" runat="server" CssClass="btn check_out_button bg-danger" Text="Proceed" OnClick="checkOutButton_Click"/>
                    <asp:Label ID="totalPrice" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
