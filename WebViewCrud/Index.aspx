<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebViewCrud.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Simple GridView CRUD</title>
    <style>
        html, body {
            margin: 0;
            width: 100%;
            height: 100%;
            overflow-x: scroll;
        }

        .center-y {
            width: 100%;
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: center;
            overflow-x: scroll !important;
        }

        .center-x {
            width: 100%;
            display: flex;
            flex-direction: row;
            justify-content: center;
            overflow-x: scroll !important;
        }

        .form-contents {
            max-width: 450px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.9.4/css/bulma.min.css" integrity="sha512-HqxHUkJM0SYcbvxUw5P60SzdOTy/QVwA1JJrvaXJv4q7lmbDZCmZaqz01UPOaQveoxfYRv1tHozWGPMcuTBuvQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
</head>
<body>
    <div class="center-y">
        <div class="center-x">


            <form id="form1" runat="server">
                <asp:GridView CssClass="table" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"
                    OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="CustomerID" HeaderText="ID" />
                        <asp:BoundField DataField="ContactName" HeaderText="Company's name" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="Country" HeaderText="Country" />
                        <asp:CommandField ControlStyle-CssClass="button is-primary" ShowEditButton="true" />
                        <asp:CommandField ControlStyle-CssClass="button is-danger" ShowDeleteButton="true" />
                        <asp:CommandField ControlStyle-CssClass="button is-secondary mt-1" ShowCancelButton="true" />
                    </Columns>
                </asp:GridView>
                <div class="container mt-5">
                    <div class="form form-contents">
                        <div class="field">
                            <label class="label">ContactName</label>
                            <div class="control">
                                <asp:TextBox CssClass="input" ID="TextBoxContactName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="field">
                            <label class="label">City</label>
                            <div class="control">
                                <asp:TextBox CssClass="input" ID="TextBoxCity" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="field">
                            <label class="label">Country</label>
                            <div class="control">
                                <asp:TextBox CssClass="input" ID="TextBoxCountry" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="field">
                            <div class="control">
                                <asp:Button CssClass="button is-link" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" runat="server" Text="Add" />
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="LabelInsertStatus" CssClass="is-danger" runat="server" Text=""></asp:Label>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
