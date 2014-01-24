<%@ Page Title="" Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style24 {
            width: 43%;
            text-align: right;
        }
        .auto-style25 {
            width: 43%;
            text-align: right;
            height: 20px;
        }
        .auto-style26 {
            height: 20px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form action="http://studentweb.centennialcollege.ca/jfilotti/Feedback.aspx">

    <p>
        &nbsp</p>
    <hr />
    <h3>
        PAMA Customer Satisfaction Survey Form</h3>
    <hr />
    <p>
        Please fill in the survey form below:</p>
    
    <table style="width:500px;">
        <tr>
            <td class="auto-style24">
        First Name:
            </td>
            <td>
        <input id="txtFName" type="text" name="txtFName" /></td>
        </tr>
        <tr>
            <td class="auto-style24">
        Last Name:</td>
            <td>
        <input id="txtLName" type="text" name="txtLName" /></td>
        </tr>
        <tr>
            <td class="auto-style24">
                Product Purchased:</td>
            <td>
        <input id="txtPwd" type="password" name="txtPwd" /></td>
        </tr>
        <tr>
            <td class="auto-style24">
                Rate Product:</td>
            <td class="style2">
        <input id="optRate5"  name="optRate" type="radio"
            value="V1" />5
        <input id="optRate4" name="optRate" type="radio"
            value="V1" />4<input id="optRate3" name="optRate" type="radio" />3<input 
                    id="optRate2" name="optRate" type="radio" />2<input id="optRate1" 
                    name="optRate" type="radio" />1</td>
        </tr>
        <tr>
            <td class="auto-style24" style="vertical-align: top">
                Product Type Purchased:</td>
            <td>
        <input id="chkOS" type="checkbox" />Digital Camera
                <br />
        <input id="chkProg" type="checkbox" />DLSR
                <br />
        <input id="chkNet" type="checkbox" />Lenses
                <br />
        <input id="chkWeb" type="checkbox" />Other</td>
        </tr>
        <tr>
            <td class="auto-style24">
        	    Feedback:
            </td>
            <td>
                <textarea id="TextArea1" name="S1"></textarea></td>
        </tr>
        <tr>
            <td class="auto-style25">
            </td>
            <td class="auto-style26">
                </td>
        </tr>
        <tr>
            <td class="auto-style24">
        <input id="btnReset" type="reset" value="Clear Form" /></td>
            <td style="text-align: center">
                <input id="btnSubmit" type="submit" value="Send" /></td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</form>

</asp:Content>

