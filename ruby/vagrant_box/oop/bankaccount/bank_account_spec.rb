require_relative "bank_account"

RSpec.describe BankAccount do



    describe "checking account" do



        before(:each) do

            @bankaccount1 = BankAccount.new

        end



        it "has a getter for balance" do

            expect(@bankaccount1.checking_balance).to eq(0)

        end



        it "can be deposited to" do

            @bankaccount1.deposit 1000, AccountType::CHECKING

            puts @bankaccount1.checking_balance

            expect(@bankaccount1.checking_balance).to eq(1000)

        end



        it "can be withdrawn from" do

            @bankaccount1.deposit 1000,AccountType::CHECKING

            @bankaccount1.withdraw 500,AccountType::CHECKING

            expect(@bankaccount1.checking_balance).to eq(500)

        end



        it "raises error if overdrawn" do

            expect{@bankaccount1.withdraw 1000, AccountType::CHECKING}.to raise_error(BankAccount::InsufficientFunds)

        end



    end



    describe "savings account" do



    end



    describe "accounts utility" do



        before(:all) do

            @bankaccount1 = BankAccount.new

        end



        it "has total account value method" do

            @bankaccount1.deposit 1000, AccountType::CHECKING

            @bankaccount1.deposit  1000, AccountType::SAVINGS



            expect{@bankaccount1.account_balances}.to output(/Your total balance: 2000/).to_stdout

        end



        it "does not allow access to total accounts" do

            expect{@bankaccount1.total_number_of_accounts}.to raise_error(NoMethodError)

        end



        # interest rate will also be a NoMethodError

        it "raises an error when the user attempts to retrieve the total number of bank accounts" do
            expect{ @bankaccount1.number_of_accounts }.to raise_error(NoMethodError)
        end

        it "raises an error when the user attempts to set the interest rate" do
            expect{ @bankaccount1.interest_rate }.to raise_error(NoMethodError)
        end



    end



end