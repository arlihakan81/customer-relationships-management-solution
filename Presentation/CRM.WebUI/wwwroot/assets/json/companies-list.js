
// Token'ý localStorage veya sessionStorage'dan al
const token = localStorage.getItem("JWToken");

$(document).ready(function () {     

    if($('#companieslist').length > 0) {
		$('#companieslist').DataTable({
				"serverSide": false,
				"bFilter": false, 
				"bInfo": false,
				"autoWidth": true,
				"language": {
					search: ' ',
					sLengthMenu: '_MENU_',
					searchPlaceholder: "Search",
					info: "_START_ - _END_ of _TOTAL_ items",
					"lengthMenu":     "Show _MENU_ entries",
					paginate: {
					next: '<i class="ti ti-chevron-right"></i> ',
					previous: '<i class="ti ti-chevron-left"></i> '
					}
				 },
				initComplete: (settings, json)=>{
					$('.dataTables_paginate').appendTo('.datatable-paginate');
					$('.dataTables_length').appendTo('.datatable-length');
				},	
			ajax: {
				url: 'https://localhost:7257/api/v1/companies?page=1&limit=100',
				type: 'GET',
				dataSrc: function (json) {
					// BaseResponse içinden PagedList'in items'ýný alýyoruz
					return json.data.items;
				},
				xhrFields: { withCredentials: true }			
			},	
			"columns": [
				{ "data": "id" },
				{ "data": "name" },
				{ "data": "email" },
				{
					"data": "status",
					"render": function (data) {
						return data
							? '<span class="badge bg-success">Active</span>'
							: '<span class="badge bg-danger">Inactive</span>';
					}
				},
				{
					"render": function () {
						return '<div class="form-check form-check-md"><input class="form-check-input" type="checkbox"></div>';
					}
				},
				{
					"render": function () {
						return '<div class="set-star rating-select"><i class="ti ti-star-filled fs-16"></i></div>';
					}
				},
				{
					"data": "avatar",
					"render": function (data, type, row) {
						return '<h6 class="d-flex align-items-center fs-14 fw-medium mb-0">'
							+ '<a href="company-details.html" class="avatar avatar-sm border rounded-circle p-1 me-2">'
							+ (data ? '<img class="w-auto h-auto" src="' + data + '" alt="User Image">' : '<i class="ti ti-user"></i>')
							+ '</a>'
							+ '<a href="/Companies/' + row.id + '" class="d-flex flex-column fw-medium">' + row.name + '</a>'
							+ '</h6>';
					}
				},
				{
					"render": function (data, type, row) {
						return '<div class="dropdown table-action"><a href="#" class="action-icon btn btn-xs shadow btn-icon btn-outline-light" data-bs-toggle="dropdown" aria-expanded="false"><i class="ti ti-dots-vertical"></i></a><div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="javascript:void(0);" data-bs-toggle="offcanvas" data-bs-target="#offcanvas_edit" data-id="'+row.id+'"><i class="ti ti-edit text-blue"></i> Edit</a><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#delete_contact"><i class="ti ti-trash"></i> Delete</a><a class="dropdown-item" href="company-details.html"><i class="ti ti-eye text-blue-light"></i> Preview</a></div></div>';
					}
				}
			]
		});
	}    
});

// Offcanvas açýlýrken tetikleme
const offcanvasEl = document.getElementById("offcanvas_edit");

offcanvasEl.addEventListener("show.bs.offcanvas", function (event) {
	// Butondan id al (örneðin data-id attribute)
	const triggerBtn = event.relatedTarget;
	const id = triggerBtn.getAttribute("data-id");

	// API'den veriyi çek
	fetch(`https://localhost:7257/api/v1/companies/${id}`, {
		method: "GET",
		credentials: "include" // withCredentials yerine bu kullanýlýr...
	})
		.then(res => res.json())
		.then(response => {
			const company = response.data;
			document.querySelector("#company_id").value = company.id;
			document.querySelector("#company_name").value = company.name;
			document.querySelector("#company_email").value = company.email;
			document.querySelector("#company_phone").value = company.phone;
			document.querySelector("#company_phone2").value = company.alternatePhone;
			document.querySelector("#company_fax").value = company.fax;
			document.querySelector("#company_website").value = company.website;
		})
		.catch(err => console.error("Veri alýnamadý:", err));
});

$(document).on("click", "#save_company_changes", function () {
	const id = document.querySelector("#company_id").value;
	const company = {
		name: document.querySelector("#company_name").value,
		email: document.querySelector("#company_email").value,
		phone: document.querySelector("#company_phone").value,
		alternatePhone: document.querySelector("#company_phone2").value,
		fax: document.querySelector("#company_fax").value,
		website: document.querySelector("#company_website").value,
		sourceId: document.querySelector("#company_source").value,
		ownerId: document.querySelector("#company_owner_id").value
	};

	fetch(`https://localhost:7257/api/v1/companies/${id}`, {
		method: "PUT",
		credentials: "include",
		headers: {
            "Content-Type": "application/json"
		},
		body: JSON.stringify(company)
	})
		.then(response => {
			console.log(JSON.stringify(company));
		})
		.then(data => {
			console.log("Ýþlem baþarýlý", data);
			// Offcanvas'ý kapat
			const offcanvas = bootstrap.Offcanvas.getInstance(offcanvasEl);

		})
	.catch(err => console.error("Ýþlem gerçekleþmedi", err));
});


$(document).ready(function () {

});


