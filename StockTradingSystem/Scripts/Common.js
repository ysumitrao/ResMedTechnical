function rebindGrid(siteId, stockId)
{
    
    var _url = '/StockDetails/ShowStockFiles';
    var valueIsSet = false;
    if (siteId != undefined && siteId != '') {
        _url += '/?siteId=' + siteId;
        valueIsSet = true;
    }

    if (stockId != undefined && stockId != '') {
        _url += valueIsSet == true ? '&stockId=' + stockId : '/?stockId=' + stockId;
        valueIsSet = true;
    }

    $.ajax({
        url: _url,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: false,
        cache: false,
        success: function (data) {
            showGrid(data);
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function getStockFiles()
{
    $("#json-overlay").show();
    $.ajax({
        url: '/StockDetails/GenerateStockFiles',
        type: "POST",
        success: function (data) {
            $("#json-overlay").hide();
            rebindGrid(ddlSite.value, ddlSymbol.value)
        },
        error: function (xhr) {
            alert('error');
        }
    });
}

function resetSelection() {
    $("#ddlSite").prop('selectedIndex', 0);
    $("#ddlSymbol").prop('selectedIndex', 0);
    rebindGrid(ddlSite.value, ddlSymbol.value);
}

function RemoveAllStockFiles()
{
    $("#json-overlay").show();
    $.ajax({
        url: '/StockDetails/RemoveAllStockFiles',
        type: "POST",
        success: function (data) {
            rebindGrid(ddlSite.value, ddlSymbol.value)
            $("#json-overlay").hide();
        },
        error: function (xhr) {
            alert('error');
        }
    });
}

$(document).ready(function() {
    rebindGrid();
});
      
function showGrid(stockFilesSrc) {
    var grid = jQuery("#stockFilesGrid");    

    grid.jqGrid({
        datatype: "local",
        data: stockFilesSrc,
        colNames: ['Id', 'Site Name', 'File Format', 'Trading Symbol', 'File Name', 'Downloaded Date', 'View File'],
        colModel: [
                    { name: 'Id', width: 1, hidden: true, key: true },
                    { name: 'Name', index: 'Name' },
                    { name: 'Format', index: 'Format' },
                    { name: 'Symbol', index: 'Symbol' },
                    { name: 'FileName', index: 'FileName' },
                    { name: 'DownloadedDate', index: 'DownloadedDate', formatter: ToJavaScriptDateTime },
                    {
                        name: 'ViewFile', sortable: false, formatter: function (cellvalue, options, rowObject) {
                            return '<a style="color:blue; text-decoration:underline" target="_blank" href="/StockDetails/ViewFiles/?stockFileId=' + rowObject.Id + '">View File</a>';
                        }
                    }
        ],
        //caption: "Stock Files",
        rowNum: 10,
        height: '100%',
        width: '100%',
        rowList: [10, 20, 50],
        loadonce: false,
        pager: '#pager',
        sortname: 'DownloadedDate',
        sortorder: "desc",
        hidegrid: false
    });

    grid.jqGrid('clearGridData');
    grid.jqGrid('setGridParam', { data: stockFilesSrc });
    grid.trigger('reloadGrid');
}

function ToJavaScriptDateTime(cellvalue, options, rowObject) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(rowObject.DownloadedDate);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getDate() + 1) + "/" + dt.getMonth() + "/" + dt.getFullYear() + " "
        + dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds() + " " + dt.getMilliseconds();
}