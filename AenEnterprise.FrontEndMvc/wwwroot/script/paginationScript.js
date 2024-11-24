 
function paginationCallBack(totalPages, currentPage) {
    const pageSize = 6;
    const maxVisiblePages = 10; // Maximum number of pages to display

    const pageLinksContainer = $('.paging');
    pageLinksContainer.empty();

    // Calculate the start and end page numbers to display
    let startPage = Math.max(1, currentPage - Math.floor(maxVisiblePages / 2));
    let endPage = Math.min(totalPages, startPage + maxVisiblePages - 1);

    // Adjust start page if the end page is less than the max visible pages
    if (endPage - startPage < maxVisiblePages - 1) {
        startPage = Math.max(1, endPage - (maxVisiblePages - 1));
    }

    // Create page links based on calculated start and end page
    for (let i = startPage; i <= endPage; i++) {
        (function (pageNumber) {
            const link = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text(pageNumber);

            if (pageNumber === currentPage) {
                link.addClass("active");
            }

            link.on('click', function () {
                $('.page-link').removeClass('active'); // Remove active class from all links
                $(this).addClass('active'); // Set active class on the clicked link

                getSalesOrders(pageNumber, pageSize); // Trigger your function with the page number
            });

            pageLinksContainer.append(link);
        })(i);
    }

    // Optionally, add "Previous" and "Next" buttons
    if (currentPage > 1) {
        const prevLink = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text('Previous');
        prevLink.on('click', function () {
            getSalesOrders(currentPage - 1, pageSize);
        });
        pageLinksContainer.prepend(prevLink);
    }

    if (currentPage < totalPages) {
        const nextLink = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text('Next');
        nextLink.on('click', function () {
            getSalesOrders(currentPage + 1, pageSize);
        });
        pageLinksContainer.append(nextLink);
    }
}

function paginationCallBackForInvoiceList(totalPages, currentPage) {
    const pageSize = 6;
    const maxVisiblePages = 10; // Maximum number of pages to display

    const pageLinksContainer = $('.paging');
    pageLinksContainer.empty();

    // Calculate the start and end page numbers to display
    let startPage = Math.max(1, currentPage - Math.floor(maxVisiblePages / 2));
    let endPage = Math.min(totalPages, startPage + maxVisiblePages - 1);

    // Adjust start page if the end page is less than the max visible pages
    if (endPage - startPage < maxVisiblePages - 1) {
        startPage = Math.max(1, endPage - (maxVisiblePages - 1));
    }

    // Create page links based on calculated start and end page
    for (let i = startPage; i <= endPage; i++) {
        (function (pageNumber) {
            const link = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text(pageNumber);

            if (pageNumber === currentPage) {
                link.addClass("active");
            }

            link.on('click', function () {
                $('.page-link').removeClass('active'); // Remove active class from all links
                $(this).addClass('active'); // Set active class on the clicked link

                getInvoices(pageNumber, pageSize); // Trigger your function with the page number
            });

            pageLinksContainer.append(link);
        })(i);
    }

    // Optionally, add "Previous" and "Next" buttons
    if (currentPage > 1) {
        const prevLink = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text('Previous');
        prevLink.on('click', function () {
            getInvoices(currentPage - 1, pageSize);
        });
        pageLinksContainer.prepend(prevLink);
    }

    if (currentPage < totalPages) {
        const nextLink = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text('Next');
        nextLink.on('click', function () {
            getInvoices(currentPage + 1, pageSize);
        });
        pageLinksContainer.append(nextLink);
    }
}

 
function paginationCallBackForDeliveryList(totalPages, currentPage) {
    const pageSize = 6;

    const pageLinksContainer = $('.paging');
    pageLinksContainer.empty();

    for (let i = 1; i <= totalPages; i++) {
        (function (pageNumber) {
            const link = $('<a>').attr({ 'href': '#', 'class': 'page-link' }).text(pageNumber);

            if (pageNumber === currentPage) {
                link.addClass("active");
            }

            link.on('click', function () {
                $('.page-link').removeClass('active'); // Remove active class from all links
                $(this).addClass('active'); // Set active class on the clicked link

                getAllDeliveryOrder(pageNumber, pageSize); // Trigger your function with the page number
            });

            pageLinksContainer.append(link);
        })(i);
    }
}