<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="LOrdCardShop.View.CardView.ManageCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .manage_card {
            display: flex;
            flex-direction: column;
            padding: 50px 10% 50px;
            gap: 30px;
        }

        .title {
            font-weight: bold;
            font-size: 32px;
        }

        .cards {
            display: flex;
            flex-wrap: wrap;
            gap: 50px;
        }

        .each_card {
            display: flex;
            width: calc(50% - 25px);
            gap: 50px;
            border-radius: 20px;
            padding: 30px 50px;
        }

        .each_card .img {
            width: 50%;
        }

        .img .card_image {
            width: 100%;
            object-fit: contain;
        }

        .information {
            display: flex;
            flex-direction: column;
            width: 100%;
            justify-content: space-around;
        }

        .information > div:not(.delete_update) {
            display: flex;
            justify-content: space-between;
            gap: 75px;
        }

        .description {
            width: 100%;
        }

        .description .description_value {
            text-align: end;
            width: 100%;
        }

        .delete_update {
            margin-top: 15px;
            display: flex;
            width: 100%;
            gap: 30px;
            justify-content: flex-end;
        }

        .delete_update > div {
            width: 80px;
        }

        .delete_button {
            width: 100%;
        }

        .update_button {
            width: 100%;
        }

        .delete_update [class*=_button] {
            color: white;
        }

        .add_card {
            margin-left: auto;
        }

        .add_card_button {
            color: white;
        }
        
        @media (max-width: 1837px) {
            .each_card {
                width: 100%;
            }
        }

        @media (max-width: 900px) {
            .each_card {
                flex-direction: column;
                align-items: center;
            }

            .each_card .img {
                width: 250px;
            }

            .information {
                gap: 20px;
            }
        }

    </style>

    <asp:Repeater ID="manageCardRepeater" runat="server">
        <HeaderTemplate>
            <div class="manage_card">
                <div class="title">
                    Manage Card
                </div>
                <div class="add_card">
                    <asp:Button ID="add_card_button" class="btn bg-danger add_card_button" runat="server" Text="Add Card" CommandName="Add" OnCommand="Action_Command"/>
                </div>
                <div class="cards">
        </HeaderTemplate>
        <ItemTemplate>
                    <div class="each_card bg-dark">
                        <div class="left img">
                            <asp:Image ID="card_image" runat="server" CssClass="card_image" ImageUrl=<%# GetCardUrl(Eval("CardName").ToString()) %>/>
                        </div>
                        <div class="right information">
                            <div class="name">
                                 <div class="name_text">
                                    Name
                                </div>
                                <div class="name_value">
                                    <asp:Label ID="name_value" runat="server" Text=<%# Eval("CardName") %>></asp:Label>
                                </div>
                            </div>
                            <div class="price">
                                <div class="price_text">
                                    Price
                                </div>
                                <div class="price_value">
                                    <asp:Label ID="price_value" runat="server" Text=<%# Eval("CardPrice") %>></asp:Label>
                                </div>
                            </div>
                            <div class="description">
                                <div class="description_text">
                                    Description
                                </div>
                                <div class="description_value">
                                    <asp:Label ID="description_value" runat="server" CssClass="value" Text=<%# Eval("CardDesc") %>></asp:Label>
                                </div>
                            </div>
                            <div class="type">
                                <div class="type_text">
                                    Type
                                </div>
                                <div class="type_value">
                                    <asp:Label ID="type_value" runat="server" Text=<%# Eval("CardType") %>></asp:Label>
                                </div>
                            </div>
                            <div class="is_foil">
                                <div class="is_foil_text">
                                    Is Foil
                                </div>
                                <div class="is_foil_value">
                                    <asp:Label ID="is_foil_value" runat="server" Text=<%#GetIsFoil(Eval("isFoil")) %>></asp:Label>
                                </div>
                            </div>
                            <div class="delete_update">
                                <div class="delete">
                                    <asp:Button ID="delete_button" class="btn bg-danger delete_button" runat="server" Text="Delete" CommandName="Delete" CommandArgument=<%# Eval("CardID") %> OnCommand="Action_Command" />
                                </div>
                                <div class="update">
                                    <asp:Button ID="update_button" class="btn bg-danger update_button" runat="server" Text="Update" CommandName="Update" CommandArgument=<%# Eval("CardID") %> OnCommand="Action_Command"/>
                                </div>
                             </div>
                        </div>
                    </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
