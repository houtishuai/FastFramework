$(function () {
    $('#input_apiKey').change(function () {
        var token = $('#input_apiKey').val();
        var bearerToken = 'Bearer ' + token;
        swaggerUi.api.clientAuthorizations.add('key', new SwaggerClient.ApiKeyAuthorization('Authorization', bearerToken, 'header'));
    });
});

