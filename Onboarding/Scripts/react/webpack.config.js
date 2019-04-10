module.exports = {
    mode: 'development',
    context: __dirname,
    entry: {
        Home: __dirname + '/index.jsx',
        Customer: __dirname + "/Customer.jsx",
        Sales: __dirname + "/Sales.jsx",
        Product: __dirname + "/Product.jsx",
        Store: __dirname + "/Store.jsx"
    },
    output:
    {
        path: __dirname + "/dist",
        filename: "[name].bundle.js"
    },
    watch: true,
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ["@babel/preset-env", "@babel/preset-react"]
                    }
                }
            },
            {
                test: /\.css?$/,
                loaders: [
                    require.resolve('style-loader'),
                    require.resolve('css-loader'),
                    require.resolve('sass-loader')
                ],
                include: __dirname
            }
            //{
            //    test: /\.css$/,
            //    include: __dirname,
            //    loaders: [
            //        require.resolve('style-loader'),
            //        require.resolve('css-loader'),
            //        require.resolve('sass-loader')
            //    ]
            //}
        ]
    }
}