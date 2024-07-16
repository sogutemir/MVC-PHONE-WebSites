///Kategori işlemleri
$(document).on("click", "#ktgEkle", async function () {
    console.log("tıklandı")
    const { value: formValues } = await Swal.fire({

        title: 'Kategori Ekle',
        html:
            '<input id="ktgAd" class="swal2-input">'


    })

    if (formValues) {
        var newKtgAd = $("#ktgAd").val();
        var form = new FormData();
        form.append("ktgAd", newKtgAd);

        $.ajax({
            "url": "/Kategori/EkleJson",
            "method": "POST",
            "timeout": 0,
            "processData": false,
            "mimeType": "multipart/form-data",
            "contentType": false,
            "data": form,
            success: function (data) {
                console.log(data);
                if (data.Result) {
                    var newRow = '<tr><td>' + data.Result.Ad + '</td><td>' + data.Result.TelefonAdet + '</td><td><button class="guncelle btn btn-custom" value="' + data.Result.Id + '">Güncelle</button></td><td><button class="sil btn btn-custom" value="' + data.Result.Id + '">Sil</button></td></tr>';
                    $('#example tbody').append(newRow);
                    
                }
                Swal.fire({
                    type: 'success',
                    title: 'Kategori Eklendi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Eklenemedi',
                    text: 'Bir Sorun ile Karşılaşıldı',
                });
            }
        });
    }
});

$(document).on("click", "#guncellee", async function () {
    var ktgId = $(this).val();
    var ktgAd = $(this).closest('tr').find('td:eq(1)').text();
    console.log(ktgId);
    console.log(ktgAd);
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Güncelle',
        html:
            '<input id="ktgAd" class="swal2-input" value="' + ktgAd + '">'
    })

    if (formValues) {
        var newKtgAd = $("#ktgAd").val();
        var form = new FormData();
        form.append("ktgId", ktgId);
        form.append("ktgAd", newKtgAd);

        $.ajax({
            "url": "/Kategori/GuncelleJson",
            "method": "POST",
            "timeout": 0,
            "processData": false,
            "mimeType": "multipart/form-data",
            "contentType": false,
            "data": form,
            success: function (data) {
                console.log(data);
                if (data.Result) {
                    var ktgAdTd = '<td>' + data.Result.Ad + '<td>';
                    var guncelleButon = "<td><button class='guncelle btn btn-custom' value='" + ktgId + "' > Güncelle</button></td > ";
                    var silButon = "<td><button class='sil btn btn-custom' value='" + ktgId + "' > Sil</button></td > ";
                    var TelefonAdet = "<td>" + data.Result.TelefonAdet + "</td>"
                    $(this).closest('tr').html(ktgAdTd + TelefonAdet + guncelleButon + silButon);
                    
                }
                
                Swal.fire({
                   
                    type: 'success',
                    title: 'Kategori Güncellendi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Güncellenmedi',
                    text: 'Bir Sorun ile Karşılaşıldı',
                });
            }
        });
    }
});

$(document).on("click", "#sill", function () {
    var ktgId = $(this).val();

    Swal.fire({
        title: 'Kategoriyi silmek istediğinize emin misiniz?',
        text: "Bu işlem geri alınamaz!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, sil!',
        cancelButtonText: 'Vazgeç'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Kategori/SilJson',
                method: 'POST',
                data: { ktgId: ktgId },
                dataType: 'json',
                success: function (data) {
                    console.log(data)
                    if (data.Result) {
                        Swal.fire(
                            'Silindi!',
                            'Kategori başarıyla silindi.',
                            'success'
                        );
                        $('#example tbody').find('tr:first-child').remove();
                        Swal.fire(
                            
                            'Silindi!',
                            'Kategori başarıyla silindi.',
                            'success'
                        );
                    }
                    
                    
                    Swal.fire(
                        'Silindi!',
                        'Kategori başarıyla silindi.',
                        'success'
                    );  
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Kategori silinemedi',
                        'error'
                    );
                }
            });
        }
    });
});

///Dukkan işlemleri
$(document).on("click", "#dknEkle", async function () {
    console.log("tıklandı")
    const { value: formValues } = await Swal.fire({

        title: 'Dükkan Ekle',
        html:
            '<input id="dknAd" class="swal2-input">'


    })

    if (formValues) {
        var newDknAd = $("#dknAd").val();
        var form = new FormData();
        form.append("dknAd", newDknAd);

        $.ajax({
            "url": "/Dukkan/EkleJson",
            "method": "POST",
            "timeout": 0,
            "processData": false,
            "mimeType": "multipart/form-data",
            "contentType": false,
            "data": form,
            success: function (data) {
                console.log(data);
                if (data.Result) {
                    var newRow = '<tr><td>' + data.Result.Ad + '</td><td>' + data.Result.TelefonAdet + '</td><td><button class="guncelle btn btn-custom" value="' + data.Result.Id + '">Güncelle</button></td><td><button class="sil btn btn-custom" value="' + data.Result.Id + '">Sil</button></td></tr>';
                    $('#example tbody').append(newRow);

                }
                Swal.fire({
                    type: 'success',
                    title: 'Kategori Eklendi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Eklenemedi',
                    text: 'Bir Sorun ile Karşılaşıldı',
                });
            }
        });
    }
});

$(document).on("click", ".guncelle", async function () {
    const button = $(this);
    const storeId = button.val();
    const storeName = button.parent().siblings(':first-child').text();

    const { value: formValues } = await Swal.fire({
        title: 'Dükkan Güncelle',
        html:
            `<input id="updatedDknAd" class="swal2-input" value="${storeName}">`
    })

    if (formValues) {
        var updatedDknAd = $("#updatedDknAd").val();
        var form = new FormData();
        form.append("dknId", storeId);
        form.append("dknAd", updatedDknAd);

        $.ajax({
            "url": "/Dukkan/GuncelleJson",
            "method": "POST",
            "timeout": 0,
            "processData": false,
            "mimeType": "multipart/form-data",
            "contentType": false,
            "data": form,
            success: function (data) {
                if (data.Result) {
                    button.parent().siblings(':first-child').text(data.Result.Ad);

                    Swal.fire({
                        type: 'success',
                        title: 'Dükkan Güncellendi',
                        text: 'İşlem başarıyla gerçekleşti'
                    });
                } else {
                    Swal.fire({
                        type: 'success',
                        title: 'Dükkan Güncellendi',
                        text: 'İşlem başarıyla gerçekleşti'
                    });
                }
            },
            error: function () {
                Swal.fire({
                    type: 'error',
                    title: 'Dükkan Güncellenemedi',
                    text: 'Bir Sorun ile Karşılaşıldı',
                });
            }
        });
    }
});

$(document).on("click", ".sil", function () {
    const button = $(this);
    const storeId = button.val();

    Swal.fire({
        title: 'Dükkan Sil',
        text: 'Bu dükkanı silmek istediğinize emin misiniz?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, sil!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                "url": "/Dukkan/SilJson",
                "method": "POST",
                "data": { "dknId": storeId },
                success: function (data) {
                    if (data.Result) {
                        button.closest('tr').remove();
                        Swal.fire({
                            type: 'success',
                            title: 'Dükkan Silindi',
                            text: 'İşlem başarıyla gerçekleşti'
                        });
                    } else {
                        Swal.fire({
                            type: 'success',
                            title: 'Dükkan Silindi',
                            text: 'İşlem başarıyla gerçekleşti'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: 'error',
                        title: 'Dükkan Silinemedi',
                        text: 'Bir Sorun ile Karşılaşıldı',
                    });
                }
            });
        }
    })
});

///Ortak işlemler
$(document).on("click", "#kategoriEkle", function () {
    var secilenDukkanAd = $("#kategoriler").val();
    var secilenId = $("#kategoriler option:selected").attr("data-id");
    var divHtml = '<div id="' + secilenId + '" class="col-md-1 bg-primary kategoriSil" style="margin-right:2px; margin-bottom:2px;">' + secilenDukkanAd + '</div>';
    $("#eklenenKategoriler").append(divHtml);
});

$(document).on("click", "#kategoriSil", function () {
    var id = $(this).attr("id");
    var secilenDukkanAd = $(this).html();
    $("#kategoriler").append('<option data-id="' + id + '">' + secilenDukkanAd + '</option>');
    $(this).remove();
});

$(document).on("click", "#dukkanEkle", function () {
    var secilenDukkanAd = $("#dukkanlar").val();
    var secilenId = $("#dukkanlar option:selected").attr("data-id");
    var divHtml = '<div id="' + secilenId + '" class="col-md-1 bg-primary dukkanSil" style="margin-right:2px; margin-bottom:2px;">' + secilenDukkanAd + '</div>';
    $("#eklenenDukkanlar").append(divHtml);
});

$(document).on("click", ".dukkanSil", function () {
    var id = $(this).attr("id");
    var secilenDukkanAd = $(this).html();
    $("#dukkanlar").append('<option data-id="' + id + '">' + secilenDukkanAd + '</option>');
    $(this).remove();
});

///Telefon İşlemleri

$(document).on("click", "#telefonKaydet", function () {
    
    var degerler = {

        kategoriler: [],
        dukkanlar: [],
        telefondurumu: $("#telefonDurum").val(),
        telefonadı : $("#telefonAdi").val(),
        telefonAlıs : $("#telefonAlıs").val(),
        telefonNo : $("#telefonNo").val(),
        Imeil : $("#Imeil").val(),
        
    };
    $("#eklenenKategoriler div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    })
    $("#eklenenDukkanlar div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.dukkanlar.push(id);
    })

    console.log(degerler.kategoriler);
    $.ajax({
        
        type: "POST",
        url: "/Telefon/EkleJson",
        data: JSON.stringify(degerler),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data=="1") {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Eklendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Telefon Eklenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
                else {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Silindi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Telefon Silinemedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }
        
    });


});

$(document).on("click", "#telefonSat", function () {

    var degerler = {

        telefonSatıs: $("#telefonSatısFiyatı").val(),
        telefonId: $(this).attr("data-id")
    };
    


    $.ajax({
        type: "POST",
        url: "/Dukkan/SatJson",
        data: JSON.stringify(degerler),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == "1") {
                Swal.fire({

                    title: 'Telefon Güncellendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({

                    type: 'error',
                    title: 'Telefon Güncellenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({

                    type: 'success',
                    title: 'Telefon Güncellendi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {
            Swal.fire({

                type: 'error',
                title: 'Telefon Güncellenmedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});

$(document).on("click", "#telefonGuncelle", function () {

    var degerler = {

        kategoriler: [],
        dukkanlar: [],
        telefonadı: $("#telefonAdi").val(),
        telefonAlıs: $("#telefonAlıs").val(),
        telefonNo: $("#telefonNo").val(),
        Imeil: $("#Imeil").val(),
        telefonId: $(this).attr("data-id")
    };
    $("#eklenenKategoriler div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    })
    $("#eklenenDukkanlar div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.dukkanlar.push(id);
    })


    $.ajax({
        type: "POST",
        url: "/Dukkan/GuncellleJson",
        data: JSON.stringify(degerler),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == "1") {
                Swal.fire({
                    
                    title: 'Telefon Güncellendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    
                    type: 'error',
                    title: 'Telefon Güncellenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({
                    
                    type: 'success',
                    title: 'Telefon Güncellendi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {
            Swal.fire({
                
                type: 'error',
                title: 'Telefon Güncellenmedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});

$(document).on("click", "#TechtelefonKaydet", function () {

    var degerler = {

        kategoriler: [],
        dukkanlar: [],
        telefondurumu: $("#TechtelefonDurum").val(),
        telefonadı: $("#TechtelefonAdi").val(),
        telefonAlıs: $("#TechtelefonAlıs").val(),
        telefonNo: $("#TechtelefonNo").val(),
        Imeil: $("#TechImeil").val(),

    };
    $("#eklenenKategoriler div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    })
    $("#eklenenDukkanlar div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.dukkanlar.push(id);
    })

    console.log(degerler.kategoriler);
    $.ajax({
        url: "/Dukkan/TechEkleJson",
        method: "POST",
        data: JSON.stringify(degerler),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data){
            if (data == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Eklendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Telefon Eklenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Silindi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {
           
            Swal.fire({
                type: 'error',
                title: 'Telefon Silinemedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});

$(document).on("click", "#TekbirtelefonKaydet", function () {

    var degerler = {

        kategoriler: [],
        dukkanlar: [],
        telefondurumu: $("#TekbirtelefonDurum").val(),
        telefonadı: $("#TekbirtelefonAdi").val(),
        telefonAlıs: $("#TekbirtelefonAlıs").val(),
        telefonNo: $("#TekbirtelefonNo").val(),
        Imeil: $("#TekbirImeil").val(),

    };
    $("#eklenenKategoriler div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    })
    $("#eklenenDukkanlar div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.dukkanlar.push(id);
    })

    console.log(degerler.kategoriler);
    $.ajax({
        url: "/Dukkan/TekbirEkleJson",
        method: "POST",
        data: JSON.stringify(degerler),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Eklendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Telefon Eklenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Silindi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Telefon Silinemedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});

$(document).on("click", "#Tk1telefonKaydet", function () {

    var degerler = {

        kategoriler: [],
        dukkanlar: [],
        telefondurumu: $("#Tk1telefonDurum").val(),
        telefonadı: $("#Tk1telefonAdi").val(),
        telefonAlıs: $("#Tk1telefonAlıs").val(),
        telefonNo: $("#Tk1telefonNo").val(),
        Imeil: $("#Tk1Imeil").val(),

    };
    $("#eklenenKategoriler div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    })
    $("#eklenenDukkanlar div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.dukkanlar.push(id);
    })

    console.log(degerler.kategoriler);
    $.ajax({
        url: "/Dukkan/Tk1EkleJson",
        method: "POST",
        data: JSON.stringify(degerler),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Eklendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Telefon Eklenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Silindi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Telefon Silinemedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});

$(document).on("click", "#Tk2telefonKaydet", function () {

    var degerler = {

        kategoriler: [],
        dukkanlar: [],
        telefondurumu: $("#Tk2telefonDurum").val(),
        telefonadı: $("#Tk2telefonAdi").val(),
        telefonAlıs: $("#Tk2telefonAlıs").val(),
        telefonNo: $("#Tk2telefonNo").val(),
        Imeil: $("#Tk2Imeil").val(),

    };
    $("#eklenenKategoriler div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    })
    $("#eklenenDukkanlar div").each(function () {
        console.log(this);
        var id = $(this).attr("id");
        degerler.dukkanlar.push(id);
    })

    console.log(degerler.kategoriler);
    $.ajax({
        url: "/Dukkan/Tk2EkleJson",
        method: "POST",
        data: JSON.stringify(degerler),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Eklendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Telefon Eklenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({
                    type: 'success',
                    title: 'Telefon Silindi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Telefon Silinemedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});



//üyelik işlemleri
$(document).on("click", "#uyeEkleYeni", async function () {

    var degerler = {

        newUyeAd: $("#uyeAdı").val(),
        newUyeSoyad: $("#uyeSoyadı").val(),
        newUyeTelefon: $("#uyeTelNo").val(),
       
    };
   

    $.ajax({
        url: "/Uye/EkleJson",
        method: "POST",
        data: JSON.stringify(degerler),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Esnaf Eklendi ',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Esnaf Eklenmedi',
                    text: 'Bos Alanlar Var',
                });
            }
            else {
                Swal.fire({
                    type: 'success',
                    title: 'Esnaf Silindi',
                    text: 'İşlem başarıyla gerçekleşti'
                });
            }
        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Esnaf Silinemedi',
                text: 'Bir Sorun ile Karşılaşıldı',
            });
        }

    });


});

$(document).on("click", "#siluser", function () {
    var userId = $(this).val();

    Swal.fire({
        title: 'Esnaf silmek istediğinize emin misiniz?',
        text: "Bu işlem geri alınamaz!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, sil!',
        cancelButtonText: 'Vazgeç'
    }).then((result) => {
        if (result.isConfirmed) {
            console.log(userId);
            $.ajax({
                url: '/Uye/SilJson',
                method: 'POST',
                data: { userId: userId },
                dataType: 'json',
                success: function (data) {
                    console.log(data)
                    if (data.Result) {
                        Swal.fire(
                            'Silindi!',
                            'Esnaf başarıyla silindi.',
                            'success'
                        );
                        $('#example tbody').find('tr:first-child').remove();
                        Swal.fire(

                            'Silindi!',
                            'Esnaf başarıyla silindi.',
                            'success'
                        );
                    }


                    Swal.fire(
                        'Silindi!',
                        'Esnaf başarıyla silindi.',
                        'success'
                    );
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Esnaf silinemedi',
                        'error'
                    );
                }
            });
        }
    });
});


//$(document).on("click", "#yeniuyeGuncelle", function () {

//    var degerler = {

//        newUyeAd: $("#uyeAdı").val(),
//        newUyeSoyad: $("#uyeSoyadı").val(),
//        newUyeTelefon: $("#uyeTelNo").val(),
//        uyeId = $("#uyeId").val()
//    };
    


//    $.ajax({
//        type: "POST",
//        url: "/Uye/GuncelleJson",
//        data: JSON.stringify(degerler),
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            if (data == "1") {
//                Swal.fire({

//                    title: 'Esnaf Güncellendi ',
//                    text: 'İşlem başarıyla gerçekleşti'
//                });
//            }
//            else if ("bosOlamaz") {
//                Swal.fire({

//                    type: 'error',
//                    title: 'Esnaf Güncellenmedi',
//                    text: 'Bos Alanlar Var',
//                });
//            }
//            else {
//                Swal.fire({

//                    type: 'success',
//                    title: 'Esnaf Güncellendi',
//                    text: 'İşlem başarıyla gerçekleşti'
//                });
//            }
//        },
//        error: function () {
//            Swal.fire({

//                type: 'error',
//                title: 'Esnaf Güncellenmedi',
//                text: 'Bir Sorun ile Karşılaşıldı',
//            });
//        }

//    });


//});