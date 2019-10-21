window.loadSwagger = {
    loadJson: function (urlswagger) {
        const ui = SwaggerUIBundle({
            url: urlswagger,
            dom_id: '#swagger-ui',
            presets: [
                SwaggerUIBundle.presets.apis,
                SwaggerUIStandalonePreset
            ],
            plugins: [
                SwaggerUIBundle.plugins.DownloadUrl
            ],
        })

        window.ui = ui
    },
};