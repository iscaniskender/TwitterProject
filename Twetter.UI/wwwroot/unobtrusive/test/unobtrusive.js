// test/unobtrusive.js

import {expect} from 'code'
import Lab from 'lab'
import Unobtrusive from './../lib'

var lab = exports.lab = Lab.script()
var {describe, it, before} = lab


describe('Unobtrusive', () => {

	it('should create a new instance of Unobtrusive', (done) => {

		expect(Unobtrusive).to.be.a.function()
		expect(Unobtrusive()).to.be.an.object()
		done()
	})

    it('should not interrupt conversations with chatter', (done) => {

        var u = Unobtrusive()
        expect(u.join).to.be.a.function()
        expect(u.join()).to.be.a.string()
        done()
    })

    it('should leave quietly', (done) => {

        var u = Unobtrusive()
        expect(u.leave).to.be.a.function()
        expect(u.leave()).to.be.a.string()
        done()
    })

    it('should be able to eat fruitcake', (done) => {

        var u = Unobtrusive();
        expect(u.eatfruitcake).to.be.a.function()
        expect(u.eatfruitcake()).to.be.a.string()
        done()
    })

    it('should be able to sing the cookie monster song', (done) => {

        var u = Unobtrusive();
        expect(u.sing).to.be.a.function()
        expect(u.sing()).to.be.a.string()
        done()
    })

    it('should be able to tell you that semicolons are awesome', (done) => {

        var u = Unobtrusive();
        expect(u.semicolon).to.be.a.function()
        expect(u.semicolon()).to.be.a.string()
        done()
    })
})
