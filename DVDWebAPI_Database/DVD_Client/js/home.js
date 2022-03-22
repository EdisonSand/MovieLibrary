$(document).ready(function () {
    loadMovies();
    globalThis.searchChoice=0;
});

function loadMovies() {
    //var contentRows = $('#contentRows');
    clearMovieTable();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44390/dvds',
        success: function (contactArray) {
            $.each(contactArray, function (index, dvd) {
                loadDVD(dvd);
            })
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({
                        class: 'list-group-item list-group-item-danger'
                    })
                    .text('Error calling web service. Please try again later.'));
        }
    });

}


function clearMovieTable() {
    $('#contentRows').empty();
}
function showEditForm(id) {
    $('#errorMessages').empty();
    $('#dvdTableDiv').hide();
    $('#editFormDiv').show();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44390/dvds/get/' + id,
        async: false,
        success: function (data, status) {
            $('#editTitle').val(data.dvdTitle);
            $('#editReleaseYear').val(data.releaseYear);
            $('#editDirector').val(data.director);
            $('#editRating').val(data.rating);
            $('#editNotes').val(data.notes);
            $('#editDvdId').val(id);
        },
        error: function (err) {
            $('#errorMessages')
                .append($('<li>')
                    .attr({
                        class: 'list-group-item list-group-item-danger'
                    })
                    .text('Error calling web service. Please try again later.'));
        }
    })


}
function showAddForm() {
    $('#errorMessages').empty();
    $('#editFormDiv').hide();
    $('#dvdTableDiv').hide();
    $('#addFormDiv').show();
}
function updateMovie() {
        
        var haveValidationErrors = checkAndDisplayValidationErrors($('#editForm').find('input'));

        if (haveValidationErrors) {
            return false;
        }
        

        $.ajax({
            type: 'PUT',
            url: 'https://localhost:44390/dvd/update/',
            async: false,
            data: JSON.stringify({
                dvdId: $('#editDvdId').val(),
                title: $('#editTitle').val(),
                releaseYear: $('#editReleaseYear').val(),
                director: $('#editDirector').val(),
                Rating: $('#editRating').val(),
                notes: $('#editNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            success: function () {
                $('#errorMessage').empty();
                hideEditForm();
                clearMovieTable();
                loadMovies();
            },
            error: function (msg) {
                console.log(msg);
                //alert(msg.responseText);
                $('#errorMessages')
                    .append($('<li>')
                        .attr({
                            class: 'list-group-item list-group-item-danger'
                        })
                        .text(msg.responseJSON.message));
                        
            }
        })
  
}



function hideEditForm() {
    $('#errorMessages').empty();

    $('#editTitle').val('');
    $('#editReleaseYear').val('');
    $('#editDirector').val('');
    $('#editRating').val('');
    $('#editNotes').val('');

    $('#dvdTableDiv').show();
    $('#editFormDiv').hide();
}
function hideAddForm() {
    $('#errorMessages').empty();

    $('#addTitle').val('');
    $('#addReleaseYear').val('');
    $('#addDirector').val('');
    $('#addRating').val('');
    $('#addNotes').val('');

    $('#dvdTableDiv').show();
    $('#addFormDiv').hide();
    $('#dvdTableDiv').show();
    
}
function addMovie() {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#addForm').find('input'));
        
        if(haveValidationErrors) {
            return false;
        }
        $.ajax({
           type: 'POST',
           url: 'https://localhost:44390/dvd/add',
           async: false,
           data: JSON.stringify({
            id: $('#addDvdId').val(),
            dvdTitle: $('#addTitle').val(),
            releaseYear: $('#addReleaseYear').val(),
            director: $('#addDirector').val(),
            rating: $('#addRating').val(),
            notes: $('#addNotes').val()
           }),
           headers: {
               'Accept': 'application/json',
               'Content-Type': 'application/json'
           },
           'dataType': 'json',
           success: function() {
               $('#errorMessages').empty();
               $('#addDvDId').val('');
               $('#addTitle').val('');
               $('#addReleaseYear').val('');
               $('#addDirector').val('');
               $('#addNotes').val('');
               hideAddForm(); 
               clearMovieTable();
               loadMovies();
           },
           error: function () {
               $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text(msg.responseJSON.message)); 
           }
        })

}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({
                class: 'list-group-item list-group-item-danger'
            }).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}
function deleteMovie(id) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44390/dvd/delete/' + id,
        async: false,
        success: function() {
            clearMovieTable();
            loadMovies();
        },
        error: function () {
            $('#errorMessages')
             .append($('<li>')
             .attr({class: 'list-group-item list-group-item-danger'})
             .text('Error calling web service. Please try again later.')); 
        }
        
    });
}
function categories(searchType){
     searchChoice = searchType;
}
function search(){

    switch (searchChoice){
        case 1:
            // ajax call to searchByTitle
            clearMovieTable();
            hideAddForm();
            hideEditForm();
            searchByTitle();
            break;
        case 2:
            //ajax call to searchByReleaseYear
            clearMovieTable();
            hideAddForm();
            hideEditForm();
            searchByReleaseYear();
            break;
        case 3:
            //ajax call to searchByDirector
            clearMovieTable();
            hideAddForm();
            hideEditForm();
            searchByDirector();
            break;
        case 4:
            //ajax call to searchByRating
            clearMovieTable();
            hideAddForm();
            hideEditForm();
            searchByRating();
            break;
        default:
            alert("Please choose a category first.");
            
            break;
    }
}

function searchByTitle(){

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44390/dvds/get/title/' + $('#searchBar').val(),
        success: function (dvd) {
                console.log(dvd);
                loadDVD(dvd);

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({
                        class: 'list-group-item list-group-item-danger'
                    })
                    .text('No titles found with the search term:  '+ $('#searchBar').val()));
        }
    });
}

function searchByReleaseYear(){

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44390/dvds/get/releaseyear/' + $('#searchBar').val(),
        success: function (contentArray) {
            $.each(contentArray, function (index, dvd) {
                loadDVD(dvd);
            })
    

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({
                        class: 'list-group-item list-group-item-danger'
                    })
                    .text('No release years found with the search term:  '+ $('#searchBar').val()));
        }
    });
}
function searchByDirector(){

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44390/dvds/get/director/' + $('#searchBar').val(),
        success: function (contentArray) {
            $.each(contentArray, function (index, dvd) {
                loadDVD(dvd);
            })
    

        },
        error: function (err) {
            $('#errorMessages')
            console.log(err)
                .append($('<li>')
                    .attr({
                        class: 'list-group-item list-group-item-danger'
                    })
                    .text('No directors found with the search term:  '+ $('#searchBar').val()));
        }
    });
}
function searchByRating(){

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44390/dvds/get/rating/' + $('#searchBar').val(),
        success: function (contentArray) {
            $.each(contentArray, function (index, dvd) {
                loadDVD(dvd);
            })
    

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({
                        class: 'list-group-item list-group-item-danger'
                    })
                    .text('No ratings found with the search term:  '+ $('#searchBar').val()));
        }
    });
}
function loadDVD(dvd){
    var contentRows = $('#contentRows');
        var dvdId = dvd.dvdId;
        var dvdTitle = dvd.dvdTitle;
        var releaseYear = dvd.releaseYear;
        var director = dvd.director;
        var rating = dvd.rating;
        var notes = dvd.notes;
        var row = '<tr>';
        row += '<td class="border-right table-hover">' + dvdTitle + '</td>';
        row += '<td class="border-right">' + releaseYear + '</td>';
        row += '<td class="border-right">' + director + '</td>';
        row += '<td class="border-right">' + rating + '</td>';
        row += '<td class="border-right">' + notes + '</td>';
        row += '<td class="border-right"><button type="button" class="btn btn-info" onclick="showEditForm(' + dvdId + ')">Edit</button></td>';
        row += '<td class="border-right"><button type="button" class="btn btn-danger" onclick="deleteMovie(' + dvdId + ')">Delete</button></td>';
        row += '</tr>';

        contentRows.append(row);
}