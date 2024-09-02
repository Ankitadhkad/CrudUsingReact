import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

export default class StudentList extends Component {
    constructor(props) {
        super(props);
        this.state = { business: [] };
        this.deleteStudent = this.deleteStudent.bind(this);
    }

    componentDidMount() {
        axios.get('http://localhost:5250/api/Student')
            .then(response => {
                this.setState({ business: response.data });
            })
            .catch(error => {
                console.log(error);
            });
    }

    deleteStudent(id) {
        if (!id) {
            console.error("ID is undefined, cannot delete.");
            return;
        }

        axios.delete('http://localhost:5250/api/Student/' + id)
            .then(response => {
                console.log('Student successfully deleted!');
                this.setState({
                    business: this.state.business.filter(student => student.id !== id)
                });
            })
            .catch(error => {
                console.error("There was an error deleting the student:", error);
            });

    }

    renderTableRows() {
        return this.state.business.map((student, index) => (
            <tr key={index}>
                <td>{student.name}</td>
                <td>{student.rollno}</td>
                <td>{student.class}</td>
                <td>{student.address}</td>
                <td>{student.gender}</td>
                <td>
                    <Link to={`/edit/${student.id}`} className="btn btn-success">Edit</Link>
                </td>
                <td>
                    <button
                        type="button"
                        onClick={() => this.deleteStudent(student.id)}
                        className="btn btn-danger"
                    >
                        Delete
                    </button>
                </td>
            </tr>
        ));
    }

    render() {
        return (
            <div>
                <h4 align="center">Student List</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Roll No</th>
                            <th>Class</th>
                            <th>Address</th>
                            <th>Gender</th>
                            <th colSpan="2">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderTableRows()}
                    </tbody>
                </table>
            </div>
        );
    }
}
