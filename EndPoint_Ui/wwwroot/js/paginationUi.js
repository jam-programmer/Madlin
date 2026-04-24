$(document).ready(function () {

    var currentPage = $("#pagination-body").data("page-index");


    var totalPages = $("#pagination-body").data("total-pages");


    var baseUrl = $("#pagination-body").data("path");


    var search = $("#pagination-body").data("search");


    var queryParams = $("#pagination-body").data("query-params") || {};
    function paginate(totalPages, currentPage, baseUrl, filter = '', queryParams = {}) {
        var paginationHtml = '<ul class="wg-pagination">';


        if (currentPage > 1) {
            paginationHtml += `  
                <li>  
                    <a class="pagination-item text-button" href="${baseUrl}?currentPage=${currentPage - 1}&Keyword=${filter}${Object.keys(queryParams).length ? '&' + $.param(queryParams) : ''}">  
                     <i class="icon-arrRight"></i>
                    </a>  
                </li>  
            `;
        } else {
            paginationHtml += '<li ><a class="pagination-item text-button" href="javascript:void(0);"> <i class="icon-arrRight"></i></a></li>';
        }

        var startPage = Math.max(1, currentPage - 2);
        var endPage = Math.min(totalPages, startPage + 4);

        if (endPage - startPage < 4) {
            startPage = Math.max(1, endPage - 4);
        }

        for (var i = startPage; i <= endPage; i++) {
            if (i === currentPage) {
                paginationHtml += `  
                    <li class="active">  
                        <a class="pagination-item text-button" href="javascript:void(0);">${i}</a>
                    </li>  
                `;
            } else {
                paginationHtml += `  
                    <li >  
                        <a class="pagination-item text-button" href="${baseUrl}?currentPage=${i}&Keyword=${filter}${Object.keys(queryParams).length ? '&' + $.param(queryParams) : ''}">${i}</a>
                    </li>  
                `;
            }
        }

        if (currentPage < totalPages) {
            paginationHtml += `  
                <li >  
                    <a class="pagination-item text-button" href="${baseUrl}?currentPage=${currentPage + 1}&Keyword=${filter}${Object.keys(queryParams).length ? '&' + $.param(queryParams) : ''}">
                   <i class="icon-arrLeft"></i>
                    </a>  
                </li>  
            `;
        } else {
            paginationHtml += '<li ><a class="pagination-item text-button" href="javascript:void(0);"><i class="icon-arrLeft"></i></a></li>';
        }

        paginationHtml += '</ul></nav>';

        $("#pagination-body").html(paginationHtml);
    }

    $("#search-input").on("input", function () {
        var searchValue = $(this).val();
        paginate(totalPages, 1, baseUrl, searchValue, queryParams);
    });

    paginate(totalPages, currentPage, baseUrl, search, queryParams);
});