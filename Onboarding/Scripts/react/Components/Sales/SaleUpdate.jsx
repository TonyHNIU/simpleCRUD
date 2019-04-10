import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Modal, Button, Form } from 'semantic-ui-react';

export default class SaleUpdate extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Success: { Data: '' },

            CustomerDropdownList: [],
            ProductDropdownList: [],
            StoresDropdownList: []
        };

        this.onClose = this.onClose.bind(this);

        this.CustomersDropdown = this.CustomersDropdown.bind(this);
        this.ProductsDropdown = this.ProductsDropdown.bind(this);
        this.StoresDropdown = this.StoresDropdown.bind(this);
    }

    componentDidMount() {
        this.CustomersDropdown();
        this.ProductsDropdown();
        this.StoresDropdown();
    }

    onClose() {
        this.setState({ showUpdateModel: false });
        window.location.reload()
    }

    CustomersDropdown() {
        $.ajax({
            url: "/Sales/GetCustomers",
            type: "GET",
            success: function (data) {
                this.setState({ CustomerDropdownList: data })
            }.bind(this)
        });
    }

    ProductsDropdown() {
        $.ajax({
            url: "/Sales/GetProducts",
            type: "GET",
            success: function (data) {
                this.setState({ ProductDropdownList: data })
            }.bind(this)
        });
    }

    StoresDropdown() {
        $.ajax({
            url: "/Sales/GetStores",
            type: "GET",
            success: function (data) {
                this.setState({ StoresDropdownList: data })
            }.bind(this)
        });
    }

    render() {
        let CustomerDataList = [].concat(this.state.CustomerDropdownList)
        let ProductDataList = [].concat(this.state.ProductDropdownList)
        let StoreDataList = [].concat(this.state.StoresDropdownList)

        return (
            <React.Fragment>
                <Modal open={this.props.showUpdateModel} onClose={this.props.onClose} size='small'>
                    <Modal.Header> Edit Sales </Modal.Header>
                    <Modal.Content>
                        <Form>
                            <Form.Field>
                                <label>Customer Name</label>
                                <select name="CustomerId" onChange={this.props.onChange} value={this.props.CustomerId}>
                                    {CustomerDataList.map((Cust) => <option key={Cust.Id} value={Cust.Id}>{Cust.CustomerName}</option>)}
                                </select>
                                <div style={{ color: 'red' }}>
                                    {this.props.errors.CustomerId}
                                </div>
                            </Form.Field>
                            <Form.Field>
                                <label>Product Name</label>
                                <select name="ProductId" onChange={this.props.onChange} value={this.props.ProductId}>
                                    {ProductDataList.map((Prod) => <option key={Prod.Id} value={Prod.Id}>{Prod.ProductName}</option>)}
                                </select>
                                <div style={{ color: 'red' }}>
                                    {this.props.errors.ProductId}
                                </div>
                            </Form.Field>
                            <Form.Field>
                                <label>Store Name</label>
                                <select name="StoreId" onChange={this.props.onChange} value={this.props.StoreId}>
                                    {StoreDataList.map((Str) => <option key={Str.Id} value={Str.Id}>{Str.StoreName}</option>)}
                                </select>
                                <div style={{ color: 'red' }}>
                                    {this.props.errors.StoreId}
                                </div>
                            </Form.Field>
                            <Form.Field>
                                <label>Date Sold</label>
                                <input type="text" name="DateSold" defaultValue={this.props.DateSold} placeholder='YYYY/MM/DD' onChange={this.props.onChange} />
                                <div style={{ color: 'red' }}>
                                    {this.props.errors.DateSold}
                                </div>
                            </Form.Field>
                        </Form>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button onClick={this.props.onClose} secondary >Cancel
                        </Button>
                        <Button onClick={this.props.onUpdateSubmit} className="ui green button">Edit
                        <i className="check icon"></i>
                        </Button>
                    </Modal.Actions>
                </Modal>
            </React.Fragment>
        )
    }
}