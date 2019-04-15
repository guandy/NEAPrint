+function ($)
{
    var neaprint = window.neaprint = window.neaprint || {};

    var host = 'http://127.0.0.1:31250/';

    var NEAPrint = function ()
    {
    };

    
    NEAPrint.prototype.PrintUrl = function (url, printFlag)
    {
        this.CheckIsInstallPrintClient(function ()
        {
            $.ajax({
                type: "POST",
                url: host,
                data: { Controller: "printurl", FileUrl: url, PrintFlag: printFlag },
                success: function (data)
                {
                    if (!data.Result)
                    {
                        alert(data.Message);
                    }
                }
            });
        })
    }

    NEAPrint.prototype.PrintBase64 = function (base64, printFlag)
    {
        this.CheckIsInstallPrintClient(function ()
        {
            $.ajax({
                type: "POST",
                url: host,
                data: { Controller: "print", PrintFlag: printFlag, FileBase64: base64 },
                success: function (data)
                {
                    if (!data.Result)
                    {
                        alert(data.Message);
                    }
                }
            });
        })
    }

    NEAPrint.prototype.CheckIsInstallPrintClient = function (callback)
    {
        var g = this;
        $.ajax({
            type: "POST",
            url: host,
            data: { Controller: "getversion" },
            success: function (data)
            {
                if (!data.Result)
                {
                    alert(data.Message);
                    return;
                }
                callback()
            },
            error: function (ex)
            {
                if (ex.statusText == "error")
                {
                    g.downPrintClient();
                }
            }
        });
    }

    NEAPrint.prototype.downPrintClient = function (callback)
    {
        if (confirm("检测到电脑没有安装打印软件(已安装请手动运行)，是否安装？"))
        {
            window.location.href = "/Content/package/setup.exe";
        }
        else
        {
            alert("未安装打印代理软件，不能进行打印操作！");
        }
    }


    $.extend(neaprint, {
        utils: new NEAPrint(),
    });

}(jQuery);