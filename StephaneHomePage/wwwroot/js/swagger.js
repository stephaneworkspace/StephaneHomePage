window.loadSwagger = {
    loadJson: function (urlswagger) {
        const ui = SwaggerUIBundle({
            url: urlswagger,
            dom_id: '#swagger-ui',
            presets: [
                SwaggerUIBundle.presets.apis,
                SwaggerUIStandalonePreset
            ]
        })

        window.ui = ui
    },
};