<%@ Page Title="Dashboard" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Dashboard.aspx.cs" Inherits="Pages_Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		.judulContent {
			/* UI Properties */
			text-align: left;
			letter-spacing: 0.7px;
			color: #303031;
			text-transform: uppercase;
			opacity: 1;
		}

		.dataTables_wrapper .dataTables_paginate .paginate_button.current, .dataTables_wrapper .dataTables_paginate .paginate_button.current {
			border: 0 !important;
			background: #1D2567 0% 0% no-repeat padding-box !important;
			color: white !important;
			text-align: center;
			margin: auto;
			margin-left: 2px;
			width: 24px !important;
			height: 30px !important;
		}

		.dataTables_wrapper .dataTables_paginate .paginate_button {
			padding: 1px;
			border-radius: 0px !important;
		}

			.dataTables_wrapper .dataTables_paginate .paginate_button:hover {
				background: #1D2567;
				color: white !important;
				height: 30px;
			}


		.btn-map {
			width: 76px;
			font-size: 12px;
			padding-bottom: 3px;
			padding-top: 3px;
			cursor: pointer;
		}

		.btn-save {
			width: 101px;
			height: 32px;
			background: #2A3593 0% 0% no-repeat padding-box;
			border-radius: 4px;
			opacity: 1;
			text-align: center;
			font: normal normal normal 12px/15px Helvetica;
			letter-spacing: 0px;
			color: #FFFFFF;
		}
	</style>

	<div class="card shadow mt-3 mr-3">
		<div class="card-body">
			<div class="judulContent mt-3" style="position: absolute; font: normal normal bold 22px/16px Helvetica;">
				LASA MEDICATION LIST
			</div>
			<div class="table-responsive">
				<table class="table row-border hover" id="tableMed">

					<thead>
						<tr class="text-center">
							<th>Drug Name</th>
							<th>Description</th>
							<th>Last Modified</th>
							<th>Action</th>
						</tr>
					</thead>
					<tbody>
						<tr class="">
							<th>Drug Name</th>
							<th>Description</th>
							<th>Last Modified</th>
							<th>Action</th>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
	</div>

	<!-- Modal -->
	<div class="modal fade" id="modalLasa" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
		<div class="modal-dialog modal-dialog-centered" role="document" style="width: 408px">
			<div class="modal-content px-3 py-2">
				<div class="modal-header" style="border: 0;">
					<h5 class="modal-title judulContent" id="exampleModalLongTitle" style="margin-top: 4px; font: normal normal bold 18px/16px Helvetica;">LASA MEDICATION LIST</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><i class="fa-solid fa-xmark"></i></button>
				</div>
				<div class="modal-body py-0">
					<input type="text" id="SalesItemId" name="name" value="" hidden />
					<asp:Label runat="server" ID="UserId" hidden></asp:Label>
					<table>
						<tr height="40px">
							<td width="100px">Drug Name</td>
							<td width="20px">:</td>
							<td id="drugName">AMILORIDE</td>
							<td></td>
						</tr>
						<tr height="40px">
							<td>Is Lasa?</td>
							<td>:</td>
							<td>
								<input id="yes" class="radioInput" type="radio" name="IsLasa" value="1" />
								<label class="ml-2">Yes</label>
								<input id="no" class="radioInput ml-3" type="radio" name="IsLasa" value="0" />
								<label class="ml-2">No</label>
							</td>
						</tr>
						<tr id="lastModified" height="40px">
							<td height="20px">Last Modified</td>
							<td>:</td>
							<td>
								<span id="modifiedDate"></span>
								- 
								<span id="modifiedTime"></span>
							</td>
						</tr>
					</table>
				</div>
				<div class="modal-footer" style="border: 0;">
					<button type="button" class="btn btn-save" data-dismiss="modal" onclick="SaveLasa()">SAVE</button>
				</div>
			</div>
		</div>
	</div>
	<script>

		function formatDate(inputDate) {
			const myArray = inputDate.split("T");
			let date = myArray[0].split("-");
			return [
				date[2],
				date[1],
				date[0],
			].join('/');
		}

		function formatTime(inputDate) {
			const myArray = inputDate.split("T");
			let time = myArray[1].split(":");
			return [
				time[0],
				time[1],
			].join(':');
		}

		var table = "";
		$(document).ready(function () {
			console.log("Berhasil");
			table = $('#tableMed').dataTable({
				"bPaginate": true,
				"bLengthChange": false,
				"bFilter": true,
				"bInfo": true,
				"bAutoWidth": false,
				"oLanguage": {
					"sSearch": "",
				},
				"language": {
					"searchPlaceholder": "🔍  Search By Drug Name",
					"info": "Result: _END_ of _TOTAL_",
					"infoEmpty": "Result: 0 of 0",
					"paginate": {
						"next": `<svg class="SVGInline-svg" id="S_NavRight_S_22" viewBox="0 0 22 22" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve" x="0px" y="0px" width="22px" height="22px">
									<g id="Layer%201">
										<path d="M 14.4775 10.3975 L 9.2876 5.2178 C 8.9878 4.9277 8.5176 4.9277 8.2178 5.2178 C 7.9277 5.5078 7.9277 5.9775 8.2178 6.2778 L 12.8779 10.9277 L 8.2178 15.5879 C 7.9277 15.8779 7.9277 16.3477 8.2178 16.6475 C 8.5176 16.9277 8.9878 16.9277 9.2876 16.6475 L 14.4678 11.4575 C 14.7578 11.1577 14.7578 10.6875 14.4775 10.3975 L 14.4775 10.3975 Z" fill="#707070"></path>
									</g>
								  </svg>`,
						"previous": `<svg class="SVGInline-svg" id="S_NavLeft_S_22" viewBox="0 0 22 22" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve" x="0px" y="0px" width="22px" height="22px">
										<g id="Layer%201">
											<path d="M 7.2092 10.3975 L 12.3992 5.2178 C 12.699 4.9277 13.1692 4.9277 13.469 5.2178 C 13.759 5.5078 13.759 5.9775 13.469 6.2778 L 8.8089 10.9277 L 13.469 15.5879 C 13.759 15.8779 13.759 16.3477 13.469 16.6475 C 13.1692 16.9277 12.699 16.9277 12.3992 16.6475 L 7.219 11.4575 C 6.929 11.1577 6.929 10.6875 7.2092 10.3975 L 7.2092 10.3975 Z" fill="#707070"></path>
										</g>
									</svg>`
					},
				},
				"bSort": false,
				'ajax': {
					'url': "https://localhost:44313/getalldatalasa",
					'dataType': 'json',
					'dataSrc': 'data'
				},
				'columns': [
					{
						'data': 'name',
						"className": "text-table-lasa"
					},
					{
						'data': null,
						'render': (data) => {
							if (data.isLasa == 0) {
								return "-";
							} else {
								return "LASA"
							}
						},
						"className": "text-table-lasa"
					},
					{
						'data': null,
						'render': (data) => {
							if (data.lasaId == 0) {
								return "-";
							} else {
								var modifiedDate = formatDate(data.modifiedDate);
								var modifiedTime = formatTime(data.modifiedDate);
								return modifiedDate + " - " + modifiedTime;
							}
						},
						"className": "text-table-lasa"
					},
					{
						'data': null,
						'render': (data, type, row) => {
							if (data.lasaId == 0) {
								return `<div onclick="modalMap('${row["salesItemId"]}')" class="btn btn-success btn-map text-center btn-modal" data-toggle="modal" data-target="#modalLasa">MAP</div>`
							} else {
								return `<a onclick="modalEdit('${row["salesItemId"]}')" href="#" class="biru font-weight-bold btn-modal" data-toggle="modal" data-target="#modalLasa">EDIT</a>`
							}
						},
						"className": "text-center"
					},
				]
			});
			$('.dataTables_filter input[type="search"]').css(
				{ 'width': '373px', 'height': '40px', 'display': 'inline-block', 'font-family': `'Helvetica', FontAwesome, sans-serif`, 'opacity': '0.7' }
			);

			$('.dataTables_filter').addClass("mb-2");
			$('.dataTables_info').css(
				{ 'text-align': 'left', 'font': 'normal normal normal 12px / 17px Helvetica', 'letter-spacing': '0.38px', 'color': '#9B9898', 'margin-top': '32.51px' }
			);
			$('.dataTables_paginate').addClass("mt-4");
		});

		function modalMap(salesItemId) {
			$("#lastModified").prop("hidden", true);
			$("#yes").prop("checked", false);
			$("#no").prop("checked", false);
			$.ajax({
				'url': "https://localhost:44313/getdatalasabyId/" + salesItemId,
				'dataSrc': 'data'
			}).done((result) => {
				$("#drugName").html(result.data[0].name);
				$("#SalesItemId").val(result.data[0].salesItemId);

			})
		}

		function modalEdit(salesItemId) {
			$("#lastModified").prop("hidden", false);

			$.ajax({
				'url': "https://localhost:44313/getdatalasabyId/" + salesItemId,
				'dataSrc': 'data'
			}).done((result) => {
				$("#drugName").html(result.data[0].name);
				$("#SalesItemId").val(result.data[0].salesItemId);
				var modifiedDate = formatDate(result.data[0].modifiedDate);
				var modifiedTime = formatTime(result.data[0].modifiedDate);
				$("#modifiedDate").html(modifiedDate);
				$("#modifiedTime").html(modifiedTime);
				if (result.data[0].isLasa) {
					$("#yes").prop("checked", true);
				} else {
					$("#no").prop("checked", true);
				}
			})
		}

		function SaveLasa() {
			var obj = new Object();
			obj.inputSalesItemId = parseInt($("#SalesItemId").val());
			obj.inputIsLasa = parseInt($("input[name='IsLasa']:checked").val());
			obj.inputUserId = parseInt($("#MainContent_UserId").html());

			if (obj.inputIsLasa == null){
				
			}
			//console.log(obj);
			const myJSON = JSON.stringify(obj);
			console.log(myJSON);
			$.ajax({
				url: "https://localhost:44313/postlasa",
				contentType: "application/json;charset=utf-8",
				type: "POST",
				data: myJSON
			}).done((result) => {
				//buat alert pemberitahuan jika success
				console.log(result);
				//alert(result.message);
				var ikon;
				var pesan;
				if (result.code == 200) {
					ikon = 'success';
					pesan = 'Success';
				}
				else {
					ikon = 'error';
					pesan = 'Error';
				}
				Swal.fire({
					icon: ikon,
					title: pesan,
					text: result.data[0].message
				});
				//reload tabel
				let table = $('#tableMed').DataTable();
				table.ajax.reload();
				//$('#modalLasa').modal('hide');
				//$('#modalLasa').removeClass('show');
				//$('.modal-backdrop').removeClass('show');
			}).fail((error) => {
				console.log(error);
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Field Cannot Be Empty'
					//text: error.statusText
				})
			})
		}

	</script>
</asp:Content>
