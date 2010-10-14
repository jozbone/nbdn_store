<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" CodeFile="DepartmentBrowser.aspx.cs" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
		<!-- for each of the main departments in the store -->
		    <%
		        foreach (var department_item in this.model)
          {
              %>
        	<tr class="ListItem">
               		 <td>                     
      <%=department_item.name%>
                	</td>
           	 </tr>        
           	 <%
          }%>
	    </table>            
</asp:Content>
